namespace Unit_1._4.Messages.Error
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
