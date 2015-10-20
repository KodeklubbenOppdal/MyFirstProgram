using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SerialRead_CsharpWPF.Message;

namespace SerialRead_CsharpWPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            MessengerInstance.Register<DoneMessage>(this, ShowMessage);

        }

        private void ShowMessage(DoneMessage obj)
        {
            ThreadMessage = obj.Message;
        }
        string _threadMessage;
        public string ThreadMessage
        {
            get { return _threadMessage; }
            set
            {
                if (value != _threadMessage)
                {
                    _threadMessage = value;
                    RaisePropertyChanged(() => ThreadMessage);
                }
            }
        }

        string _dataRecived;
        public string DataRecived
        {
            get { return _dataRecived; }
            set
            {
                if (value != _dataRecived)
                {
                    _dataRecived = value;
                    RaisePropertyChanged(() => DataRecived);
                }
            }

        }

    }
}