namespace Unit_1._4_Rx.Models
{
    public class FileWrite
    {
        public FileWrite(string newText)
        {
            NewText = newText;
        }

        public string NewText { get; private set; }
    }
}
