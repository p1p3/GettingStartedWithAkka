namespace Unit_1._3.Messages.Error
{
    public class InputError
    {
        public InputError(string reason)
        {
            Reason = reason;
        }

        public string Reason { get; private set; }
    }
}
