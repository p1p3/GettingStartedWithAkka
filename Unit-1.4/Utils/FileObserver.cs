using System;
using System.IO;
using Akka.Actor;

namespace Unit_1._4.Utils
{
    public class FileObserver : IDisposable
    {
        private readonly IActorRef _tailActor;
        private readonly string _absoluteFilePath;
        private FileSystemWatcher _watcher;
        private readonly string _fileDir;
        private readonly string _fileNameOnly;

        public FileObserver(IActorRef tailActor, string absoluteFilePath)
        {
            _tailActor = tailActor;
            _absoluteFilePath = absoluteFilePath;
            _fileDir = Path.GetDirectoryName(absoluteFilePath);
            _fileNameOnly = Path.GetFileName(absoluteFilePath);
        }

        public void Start()
        {
            _watcher = new FileSystemWatcher(_fileDir, _fileNameOnly)
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
            };

            // assign callbacks for event types
            _watcher.Changed += OnFileChanged;
            _watcher.Error += OnFileError;

            // start watching
            _watcher.EnableRaisingEvents = true;
        }


        private void OnFileError(object sender, ErrorEventArgs e)
        {
            _tailActor.Tell(new Messages.Tail.FileError(_fileNameOnly,e.GetException().Message),ActorRefs.NoSender);
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                // here we use a special ActorRefs.NoSender
                // since this event can happen many times,
                // this is a little microoptimization
                _tailActor.Tell(new Messages.Tail.FileWrite(e.Name), ActorRefs.NoSender);
            }

        }

        public void Dispose()
        {
            _watcher.Dispose();;
        }
    }
}
