using System;
using System.IO.Ports;

namespace Snap_and_Print.Services
{
    public class PaymentController
    {
        private SerialPort serialPort;

        public event Action PaymentUpdated;

        public bool Connect()
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                try
                {
                    serialPort = new SerialPort(port, 9600);

                    serialPort.NewLine = "\n";
                    serialPort.ReadTimeout = 1000;
                    serialPort.WriteTimeout = 1000;

                    serialPort.DataReceived += SerialPort_DataReceived;

                    serialPort.Open();

                    return true;
                }
                catch
                {
                    // Try next COM port
                }
            }

            return false;
        }

        public void Disconnect()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        public void StartPayment(int totalAmount)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.WriteLine($"SETTOTAL:{totalAmount}");
            }
        }

        public void ResetPayment()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.WriteLine("RESET");
            }
        }

        public void GetStatus()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.WriteLine("GETSTATUS");
            }
        }

        public int TotalAmount { get; private set; }

        public int InsertedPayment { get; private set; }

        public int Balance { get; private set; }

        public int Change { get; private set; }

        public string Status { get; private set; } = "";

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine().Trim();

            ProcessData(data);
        }

        private void ProcessData(string data)
        {
            if (data.StartsWith("TOTAL:"))
            {
                TotalAmount = int.Parse(data.Substring(6));
            }
            else if (data.StartsWith("PAYMENT:"))
            {
                InsertedPayment = int.Parse(data.Substring(8));
            }
            else if (data.StartsWith("BALANCE:"))
            {
                Balance = int.Parse(data.Substring(8));
            }
            else if (data.StartsWith("CHANGE:"))
            {
                Change = int.Parse(data.Substring(7));
            }
            else if (data.StartsWith("STATUS:"))
            {
                Status = data.Substring(7);
            }

            if (PaymentUpdated != null)
            {
                PaymentUpdated();
            }
        }
    }

}