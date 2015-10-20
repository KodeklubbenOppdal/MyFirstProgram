using System.Threading.Tasks;
using System.Windows;
using System.IO.Ports;
using System.Windows.Threading;
using SerialRead_CsharpWPF.Message;
using SerialRead_CsharpWPF.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace SerialRead_CsharpWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        SerialPort serialPort = new SerialPort();
        MainViewModel viewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;

        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
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

        private delegate void UpdateUiTextDelegate(string text);

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {

            SerialPort sp = (SerialPort)sender;
            if (serialPort.IsOpen)
            {
                string dataRecived = sp.ReadLine();
                dataRecived.Trim();
                viewModel.DataRecived = dataRecived;
                Task task = new Task(new Action(ParsString));
                task.Start();
                Dispatcher.Invoke(DispatcherPriority.Send, new UpdateUiTextDelegate(ShowData), dataRecived);



            }

        }

        private void ParsString()
        {
            int number = 0;
            if (int.TryParse(viewModel.DataRecived, out number))
            {

                Messenger.Default.Send(new DoneMessage(string.Format("Ferdig med å vente {0} i tråden {1}", number, Task.CurrentId.Value.ToString())));
            }

        }

        private void ShowData(string inn)
        {
            txtResived.Text = inn;
        }
    }
    
}
