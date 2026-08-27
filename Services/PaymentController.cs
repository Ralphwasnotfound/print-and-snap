using System;
using System.IO.Ports;

namespace Snap_and_Print.Services
{
    public class PaymentController
    {
        private SerialPort serialPort;

        public event Action PaymentUpdated;
        public event Action BillDetected;

        // =====================================================
        // CONNECTION STATUS
        // =====================================================

        public bool IsConnected
        {
            get
            {
                return serialPort != null && serialPort.IsOpen;
            }
        }


        // =====================================================
        // PAYMENT VALUES
        // =====================================================

        public int TotalAmount { get; private set; }

        public int InsertedPayment { get; private set; }

        public int Balance { get; private set; }

        public int Change { get; private set; }

        public string Status { get; private set; } = "";


        // =====================================================
        // HARDWARE STATUS
        // =====================================================

        public bool CoinAcceptorReady { get; private set; }

        public bool BillAcceptorReady { get; private set; }

        public bool CoinDispenserReady { get; private set; }

        public bool BillDispenserReady { get; private set; }


        // =====================================================
        // CONNECT
        // =====================================================

        public bool Connect()
        {
            string[] ports = SerialPort.GetPortNames();

            if (ports.Length == 0)
            {
                System.Windows.Forms.MessageBox.Show(
                    "No COM ports found.\n\n" +
                    "Please check the Arduino USB connection."
                );

                return false;
            }

            string errors = "";

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

                    // Successfully connected
                    return true;
                }
                catch (Exception ex)
                {
                    errors +=
                        port + " → " +
                        ex.Message + "\n\n";

                    try
                    {
                        if (serialPort != null && serialPort.IsOpen)
                            serialPort.Close();
                    }
                    catch
                    {
                    }
                }
            }

            System.Windows.Forms.MessageBox.Show(
                "Could not connect to the Arduino.\n\n" +
                "COM port errors:\n\n" +
                errors
            );

            return false;
        }


        // =====================================================
        // DISCONNECT
        // =====================================================

        public void Disconnect()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }

            CoinAcceptorReady = false;
            BillAcceptorReady = false;
            CoinDispenserReady = false;
            BillDispenserReady = false;
        }


        // =====================================================
        // CHECK HARDWARE
        // =====================================================

        public bool CheckHardware()
        {
            if (!IsConnected)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Hardware connection failed.\nPlease check the Arduino connection."
                );

                return false;
            }

            try
            {
                serialPort.WriteLine("GETSTATUS");

                // No success message.
                // The normal hardware check will determine
                // whether all devices are ready.

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Hardware check failed.\n\n" +
                    "Error:\n" +
                    ex.Message
                );

                return false;
            }
        }

        // =====================================================
        // PAYMENT
        // =====================================================

        public void StartPayment(int totalAmount)
        {
            if (!IsConnected)
                return;

            // Reset local payment state
            TotalAmount = totalAmount;
            InsertedPayment = 0;
            Balance = totalAmount;
            Change = 0;
            Status = "WAITING FOR PAYMENT";

            // Update UI immediately
            PaymentUpdated?.Invoke();

            // Tell Arduino the new payment target
            serialPort.WriteLine($"SETTOTAL:{totalAmount}");
        }


        public void ResetPayment()
        {
            if (!IsConnected)
                return;

            TotalAmount = 0;
            InsertedPayment = 0;
            Balance = 0;
            Change = 0;
            Status = "";

            PaymentUpdated?.Invoke();

            serialPort.WriteLine("RESET");
        }


        public void GetStatus()
        {
            if (!IsConnected)
                return;

            serialPort.WriteLine("GETSTATUS");
        }

        // =====================================================
        // BILL PAYMENT
        // =====================================================

        public void AddBillPayment(int amount)
        {
            if (!IsConnected)
                return;

            if (amount != 50 &&
                amount != 100 &&
                amount != 500 &&
                amount != 1000)
                return;

            serialPort.WriteLine($"BILL:{amount}");
        }

        // =====================================================
        // SERIAL DATA RECEIVED
        // =====================================================

        private void SerialPort_DataReceived(
            object sender,
            SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine().Trim();

                ProcessData(data);
            }
            catch
            {
                // Ignore invalid serial data
            }
        }


        // =====================================================
        // PROCESS DATA
        // =====================================================

        private void ProcessData(string data)
        {
            if (data.StartsWith("TOTAL:"))
            {
                TotalAmount =
                    int.Parse(data.Substring(6));
            }

            else if (data.StartsWith("PAYMENT:"))
            {
                InsertedPayment =
                    int.Parse(data.Substring(8));
            }

            else if (data.StartsWith("BALANCE:"))
            {
                Balance =
                    int.Parse(data.Substring(8));
            }

            else if (data.StartsWith("CHANGE:"))
            {
                Change =
                    int.Parse(data.Substring(7));
            }

            else if (data.StartsWith("STATUS:"))
            {
                Status =
                    data.Substring(7);
            }

            // =================================================
            // BILL DETECTED
            // =================================================

            else if (data == "BILL:PRESENT")
            {
                BillDetected?.Invoke();
            }

            // =================================================
            // ACCEPTORS
            // =================================================

            else if (data == "COIN_ACCEPTOR:READY")
            {
                CoinAcceptorReady = true;
            }

            else if (data == "BILL_ACCEPTOR:READY")
            {
                BillAcceptorReady = true;
            }

            // =================================================
            // DISPENSERS
            // =================================================

            else if (data == "COIN_DISPENSER:READY")
            {
                CoinDispenserReady = true;
            }

            else if (data == "BILL_DISPENSER:READY")
            {
                BillDispenserReady = true;
            }


            PaymentUpdated?.Invoke();
        }


        // =====================================================
        // DISPENSERS
        // =====================================================

        public void DispenseOnePeso()
        {
            if (IsConnected)
            {
                serialPort.WriteLine("DISPENSE:1");
            }
        }


        public void DispenseFivePeso()
        {
            if (IsConnected)
            {
                serialPort.WriteLine("DISPENSE:5");
            }
        }


        public void DispenseTenPeso()
        {
            if (IsConnected)
            {
                serialPort.WriteLine("DISPENSE:10");
            }
        }


        public void DispenseTwentyPeso()
        {
            if (IsConnected)
            {
                serialPort.WriteLine("DISPENSE:20");
            }
        }


        public void DispenseFiftyPeso()
        {
            if (IsConnected)
            {
                serialPort.WriteLine("DISPENSE:50");
            }
        }


        public void DispenseOneHundredPeso()
        {
            if (IsConnected)
            {
                serialPort.WriteLine("DISPENSE:100");
            }
        }


        public void StopDispensers()
        {
            if (IsConnected)
            {
                serialPort.WriteLine("STOPDISPENSERS");
            }
        }


    }

}