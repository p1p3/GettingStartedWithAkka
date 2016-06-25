using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_1_RX.Observables;
using Unit_1_RX.Observers;

namespace Unit_1_RX
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleReader = new ConsoleReader();
            var consoleEvenCharsObserver = new ConsoleOddChars();
            consoleReader.Subscribe(consoleEvenCharsObserver);

            Console.WriteLine("Please type something");
        }
    }
}
