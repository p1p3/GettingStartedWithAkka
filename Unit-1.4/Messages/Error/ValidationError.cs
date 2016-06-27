namespace Unit_1._4.Messages.Error
{
    public  class ValidationError:InputError
    {
        public ValidationError(string reason) : base(reason)
        {
        }
    }
}
