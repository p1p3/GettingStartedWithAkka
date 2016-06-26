using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Unit_1._2.Actors;

namespace Unit_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("ActorSystem");

            var consoleWriterActor = system.ActorOf<ConsoleWriterActor>("consoleWriter");
            var consoleReaderActor = system.ActorOf(Props.Create(() =>
                new ConsoleReaderActor(consoleWriterActor)));


            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);


            system.WhenTerminated.Wait();
        }
    }
}
