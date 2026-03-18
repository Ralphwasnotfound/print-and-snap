using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using PdfiumViewer;

namespace PrintAndSnap.Services.Printing
{
    public class DocumentPrinting
    {
        // =========================
        // MAIN PRINT FUNCTION
        // =========================
        public bool PrintDocumentFile(
            string currentPdfPath,
            string printerName,
            int totalPages,
            bool isSinglePage,
            int singlePage,
            bool isRange,
            string pageRangeText,
            bool isColored,
            List<bool> pageIsColored
        )
        {
            bool printSuccess = false;

            try
            {
                if (!PrinterExists(printerName) || !IsPrinterOnline(printerName))
                {
                    ClearPrinterQueue(printerName);
                    return false;
                }

                if (!File.Exists(currentPdfPath))
                {
                    return false;
                }

                using (var document = PdfDocument.Load(currentPdfPath))
                {
                    int startPage = 1;
                    int endPage = totalPages;

                    // SINGLE PAGE
                    if (isSinglePage)
                    {
                        startPage = singlePage;
                        endPage = singlePage;
                    }

                    // RANGE
                    else if (isRange && pageRangeText.Contains("-"))
                    {
                        var parts = pageRangeText.Split('-');

                        startPage = int.Parse(parts[0]);
                        endPage = int.Parse(parts[1]);
                    }

                    // PRINT PAGE BY PAGE
                    for (int page = startPage; page <= endPage; page++)
                    {
                        var printDoc = document.CreatePrintDocument();

                        printDoc.PrinterSettings.PrinterName = printerName;

                        printDoc.PrintController =
                            new System.Drawing.Printing.StandardPrintController();

                        printDoc.PrinterSettings.PrintRange =
                            System.Drawing.Printing.PrintRange.SomePages;

                        printDoc.PrinterSettings.FromPage = page;
                        printDoc.PrinterSettings.ToPage = page;

                        // COLOR OR BW
                        if (isColored && pageIsColored != null && pageIsColored.Count >= page)
                        {
                            bool isColor = pageIsColored[page - 1];
                            printDoc.DefaultPageSettings.Color = isColor;
                        }
                        else
                        {
                            printDoc.DefaultPageSettings.Color = false;
                        }

                        printDoc.Print();
                    }

                    printSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ClearPrinterQueue(printerName);
                Debug.WriteLine("Printing error: " + ex.Message);
                return false;
            }

            return printSuccess;
        }

        // =========================
        // PRINTER HELPERS
        // =========================
        private bool PrinterExists(string printerName)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (printer.Equals(printerName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        private bool IsPrinterOnline(string printerName)
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

        private string GetPrinterStatus(string printerName)
        {
            string query = $"SELECT * FROM Win32_Printer WHERE Name = '{printerName}'";

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject printer in searcher.Get())
                {
                    if (printer["WorkOffline"] != null && (bool)printer["WorkOffline"])
                        return "Printer Offline";

                    if (printer["PrinterStatus"] != null)
                    {
                        int status = Convert.ToInt32(printer["PrinterStatus"]);

                        switch (status)
                        {
                            case 3: return "Printer Ready";
                            case 4: return "Printing";
                            case 5: return "Printer Warming Up";
                            case 6: return "Printer Stopped";
                            case 7: return "Printer Offline";
                            default: return "Printer Error";
                        }
                    }
                }
            }

            return "Printer Not Found";
        }

        private string GetDetailedPrinterError(string printerName)
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
                            case 6: return "Printer Door Open";
                            case 7: return "Printer Offline";
                            case 8: return "Out of Toner / Ink";
                            case 9: return "Low Toner / Ink";
                            case 10: return "Printer Error";
                            default: return "Unknown Printer Error";
                        }
                    }
                }
            }

            return "No Error";
        }

        private void ClearPrinterQueue(string printerName)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c net stop spooler && del /Q /F %systemroot%\\System32\\spool\\PRINTERS\\*.* && net start spooler";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();
            }
            catch { }
        }
    }
}