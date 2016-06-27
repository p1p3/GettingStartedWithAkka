namespace Unit_1._4.Messages.Tail
{
    public class StopTail
    {
        public StopTail(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; private set; }
    }
}