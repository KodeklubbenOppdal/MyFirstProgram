namespace SerialRead_CsharpWPF.Message
{
    public class DoneMessage
    {
        public string Message { get; private set; }

        public DoneMessage(string message)
        {
            Message = message;
        }
    }
}
