using System;
using System.Diagnostics;
using System.Management;

namespace PrintAndSnap.Services
{
    public class PrinterManager
    {
        public bool PrinterExists(string printerName)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (printer.Equals(printerName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public bool IsPrinterOnline(string printerName)
        {
            string query = $"SELECT * FROM Win32_Printer WHERE Name = '{printerName}'";

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject printer in searcher.Get())
                {
                    bool offline = printer["WorkOffline"] != null && (bool)printer["WorkOffline"];
                    return !offline;
                }
            }

            return false;
        }

        public string GetPrinterStatus(string printerName)
        {
            string query = $"SELECT * FROM Win32_Printer WHERE Name = '{printerName}'";

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject printer in searcher.Get())
                {
                    if ((bool)printer["WorkOffline"])
                        return "Printer Offline";

                    int status = Convert.ToInt32(printer["PrinterStatus"]);

                    switch (status)
                    {
                        case 3: return "Printer Ready";
                        case 4: return "Printing";
                        case 5: return "Warming Up";
                        case 6: return "Stopped";
                        case 7: return "Offline";
                        default: return "Error";
                    }
                }
            }

            return "Not Found";
        }

        public string GetDetailedPrinterError(string printerName)
        {
            string query = $"SELECT * FROM Win32_Printer WHERE Name = '{printerName}'";

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject printer in searcher.Get())
                {
                    if (printer["DetectedErrorState"] != null)
                    {
                        int error = Convert.ToInt32(printer["DetectedErrorState"]);

                        switch (error)
                        {
                            case 0: return "No Error";
                            case 3: return "Paper Jam";
                            case 4: return "Out of Paper";
                            case 5: return "Paper Problem";
                            case 6: return "Door Open";
                            case 7: return "Offline";
                            case 8: return "Out of Ink";
                            case 9: return "Low Ink";
                            default: return "Printer Error";
                        }
                    }
                }
            }

            return "No Error";
        }

        public void ClearPrinterQueue()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c net stop spooler && del /Q /F %systemroot%\\System32\\spool\\PRINTERS\\*.* && net start spooler",
                    CreateNoWindow = true,
                    UseShellExecute = false
                })?.WaitForExit();
            }
            catch { }
        }

        public bool IsPrinterReady(string printerName)
        {
            if (!PrinterExists(printerName)) return false;
            if (!IsPrinterOnline(printerName)) return false;

            string status = GetPrinterStatus(printerName);

            return status == "Printer Ready" || status == "Printing";
        }
    }
}