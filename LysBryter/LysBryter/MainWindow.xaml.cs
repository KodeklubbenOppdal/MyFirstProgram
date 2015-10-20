using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Windows.Threading;

namespace LysBryter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort serialPort = new SerialPort();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            serialPort.PortName = "COM13";
            serialPort.BaudRate = 9600;
            try
            {
                serialPort.Open();
                serialPort.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            }
            catch (Exception)
            {
                MessageBox.Show("Kan ikke kontakte serial port");

            }

        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {

            SerialPort sp = (SerialPort)sender;
            if (serialPort.IsOpen)
            {
                string dataRecived = sp.ReadLine();
                dataRecived.Trim();
               // Dispatcher.Invoke(DispatcherPriority.Send, new UpdateUiTextDelegate(ShowData), dataRecived);
            }

        }

        private void btnOn_Click(object sender, RoutedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("on");
            }

            else
            {
                NoSerialConnection();
            }
        }

        private void NoSerialConnection()
        {
            MessageBox.Show("Ingen seriel forbindelse");
        }

        private void btnOff_Click(object sender, RoutedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine("off");
            }

            else
            {
                NoSerialConnection();
            }
        }
    }
}
