namespace Unit_1._4_Rx.Models
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