using System.IO;
using System.Text;
using Akka.Actor;
using Unit_1._4.Messages.Tail;
using Unit_1._4.Utils;

namespace Unit_1._4.Actors.TailCoordinator
{
    public class TailActor : TypedActor, IHandle<FileWrite>, IHandle<InitialRead>, IHandle<FileError>
    {


        private readonly string _filePath;
        private readonly IActorRef _reporterActor;
        private readonly FileObserver _observer;
        private readonly Stream _fileStream;
        private readonly StreamReader _fileStreamReader;


        public TailActor(IActorRef reporterActor, string filePath)
        {
            _reporterActor = reporterActor;
            _filePath = filePath;

            // start watching file for changes
            _observer = new FileObserver(Self, Path.GetFullPath(_filePath));
            _observer.Start();

            // open the file stream with shared read/write permissions
            // (so file can be written to while open)
            _fileStream = new FileStream(Path.GetFullPath(_filePath),FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            _fileStreamReader = new StreamReader(_fileStream, Encoding.UTF8);

            // read the initial contents of the file and send it to console as first msg
            var text = _fileStreamReader.ReadToEnd();
            Self.Tell(new InitialRead(_filePath, text));
        }


        public void Handle(FileWrite message)
        {
            // move file cursor forward
            // pull results from cursor to end of file and write to output
            // (this is assuming a log file type format that is append-only)
            var text = _fileStreamReader.ReadToEnd();
            if (!string.IsNullOrEmpty(text))
            {
                _reporterActor.Tell(text);
            }
        }

        public void Handle(InitialRead message)
        {
            _reporterActor.Tell(message.Text);
        }

        public void Handle(FileError message)
        {
            _reporterActor.Tell($"Tail error: {message.Reason}");
        }
    }
}
