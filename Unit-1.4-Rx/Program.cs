using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_1._4_Rx.Observables;
using Unit_1._4_Rx.Observers;

namespace Unit_1._4_Rx
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Type the path of the file");
            var filePath = Console.ReadLine();

            var fileObserver = new FileObservable(filePath);
            var fileChangedObserver = new FileChanged();
            fileObserver.Subscribe(fileChangedObserver);

            Console.WriteLine("Start edditing your file");
            Console.ReadLine();
        }
    }
}
