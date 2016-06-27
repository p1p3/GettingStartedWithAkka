namespace Unit_1._4.Messages.Success
{
    public class InputSuccess
    {
        public InputSuccess(string reason)
        {
            Reason = reason;
        }

        public string Reason { get; private set; }
    }
}
