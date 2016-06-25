namespace Unit_1_RX.Models
{
    internal class ConsoleInput
    {
        public ConsoleInput(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}