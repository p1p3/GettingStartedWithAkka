using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_1._4_Rx.Models;

namespace Unit_1._4_Rx.Observables
{
    public class FileObservable : IObservable<FileWrite>, IDisposable
    {
        private readonly string _absoluteFilePath;
        private FileSystemWatcher _watcher;
        private readonly string _fileDir;
        private readonly string _fileNameOnly;
        private readonly Stream _fileStream;
        private readonly StreamReader _fileStreamReader;

        public FileObservable(string absoluteFilePath)
        {
            _absoluteFilePath = absoluteFilePath;
            _fileDir = Path.GetDirectoryName(absoluteFilePath);
            _fileNameOnly = Path.GetFileName(absoluteFilePath);

            _fileStream = new FileStream(Path.GetFullPath(_absoluteFilePath), FileMode.Open, FileAccess.Read,
                FileShare.ReadWrite);
            _fileStreamReader = new StreamReader(_fileStream, Encoding.UTF8);

            ReadLastLine();
        }


        public IDisposable Subscribe(IObserver<FileWrite> observer)
        {
            _watcher = new FileSystemWatcher(_fileDir, _fileNameOnly)
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                EnableRaisingEvents = true
            };


            var fswCreated = Observable.FromEvent<FileSystemEventHandler, FileSystemEventArgs>(handler =>
            {
                FileSystemEventHandler fsHandler = (sender, e) => { handler(e); };

                return fsHandler;
            },
                fsHandler => _watcher.Changed += fsHandler,
                fsHandler => _watcher.Changed -= fsHandler).Select(x => new FileWrite(ReadLastLine()));


            return fswCreated.Subscribe(observer);
        }

        public string ReadLastLine()
        {
            var text = _fileStreamReader.ReadToEnd();
            return text;
        }

        public void Dispose()
        {
            _watcher?.Dispose();
            _fileStream?.Dispose();
            _fileStreamReader?.Dispose();
        }
    }
}