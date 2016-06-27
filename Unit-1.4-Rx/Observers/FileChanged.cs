using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_1._4_Rx.Models;

namespace Unit_1._4_Rx.Observers
{
    class FileChanged:IObserver<FileWrite>
    {
        public void OnNext(FileWrite file)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(file.NewText);
            Console.ResetColor();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
