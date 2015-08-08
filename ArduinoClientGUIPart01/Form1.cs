using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace ArduinoControllerPart01
{
    public partial class ArduinoController : Form
    {
        SerialPort serialPort;
        enum Command { SET_BINARY = 0, SET_ANALOG, QUERY };
        enum BinarySet { OFF = 0, ON };

        char[] m_Command = new char[2];

        /// <summary>
        /// The constructor does the following:
        /// - Detect the Arduino's com port from the device manager
        /// - Initiate the serial connection to the Arduino board
        /// 
        /// </summary>
        public ArduinoController()
        {
            InitializeComponent();

            // Detecting Arduino's com port from Windows device manager
            string comPort = AutodetectArduinoPort(); 
            string msg;

            if (!string.IsNullOrEmpty(comPort))
            {
                msg = string.Format("Arduino comPort=[{0}]\n", comPort);
                LogDisplay.AppendText(msg);

                try
                {
                    serialPort = new SerialPort(comPort, 9600, Parity.None, 8, StopBits.One);
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceiveHandler);
                    serialPort.Open();

                    if (serialPort.IsOpen)
                    {
                        LogDisplay.AppendText("Successfully connected to Arduino\n");
                    }
                    else
                    {
                        LogDisplay.AppendText("Error: Connection to Arduino failed\n");
                    }

                }
                catch (IOException e)
                {
                    LogDisplay.AppendText("IOException: " + e.ToString());

                }
                catch (ArgumentOutOfRangeException e)
                {
                    LogDisplay.AppendText("ArgumentOutOfRangeException: " + e.ToString());

                }
                catch (ArgumentException e)
                {
                    LogDisplay.AppendText("ArgumentOutOfRangeException: " + e.ToString());

                }
                catch (UnauthorizedAccessException e)
                {
                    LogDisplay.AppendText("UnauthorizedAccessException: " + e.ToString());

                }
                catch (InvalidOperationException e)
                {
                    LogDisplay.AppendText("InvalidOperationException: " + e.ToString());

                }
            }
            else // Will not go further is no Arduino board can be found
            {
                msg = string.Format("The Arduino cannot be found. Please plug in the board and re-start the client GUI\n");
                LogDisplay.AppendText(msg);
                BinaryControl.Enabled = false;
                QueryButton.Enabled = false;
                AnalogControl.Enabled = false;
            }

        }

        /// <summary>
        /// Autodetect the arduino com port from device manager.
        /// </summary>
        /// <returns>The com port if found</returns>
        private string AutodetectArduinoPort()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException e)
            {
                LogDisplay.AppendText(e.ToString());
            }
            return null;
        }
        private void DataReceiveHandler(object sender, SerialDataReceivedEventArgs arg)
        {
            SerialPort sp = (SerialPort)sender;
            try
            {
                string incomingMsg = sp.ReadLine();
                incomingMsg.Trim();
                LogDisplay.AppendText(incomingMsg);
            }
            catch (System.InvalidOperationException e)
            {
                string errorMsg = "IOException source: ";
                errorMsg += e.Source;
                LogDisplay.AppendText(errorMsg);
            }
        }

        private void SendToArduino(string msg)
        {
            try
            {
                serialPort.Write(msg);
            }
            catch (System.InvalidOperationException e)
            {
                string errorMsg = "IOException source: ";
                errorMsg += e.Source;
                LogDisplay.AppendText(errorMsg);
            }
        }

        private void BinaryControl_CheckedChanged(object sender, EventArgs e)
        {
            m_Command[0] = (char)Command.SET_BINARY;
            if (BinaryControl.Checked)
            {
                BinaryControl.Text = "On";
                m_Command[1] = (char)BinarySet.ON;
            }
            else
            {
                BinaryControl.Text = "Off";
                m_Command[1] = (char)BinarySet.OFF;
            }

            SendToArduino(new string(m_Command));

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void AnalogControl_Scroll(object sender, EventArgs e)
        {

            m_Command[0] = (char)Command.SET_ANALOG;
            m_Command[1] = (char)AnalogControl.Value;

            SendToArduino(new string(m_Command));
        }

        private void QueryButton_Click(object sender, EventArgs e)
        {
            m_Command[0] = (char)Command.QUERY;
            m_Command[1] = (char)2;

            SendToArduino(new string(m_Command));

        }
    }
}
