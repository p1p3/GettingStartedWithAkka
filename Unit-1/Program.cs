using Akka.Actor;
using Unit_1.Actors;
using Unit_1.Model;

namespace Unit_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            var system = ActorSystem.Create("ActorSystem");

            var consoleWriterActor = system.ActorOf<ConsoleWriterActor>("consoleWriter");
            var consoleReaderActor = system.ActorOf(Props.Create(() =>
                new ConsoleReaderActor(consoleWriterActor)));


            consoleReaderActor.Tell("start");


            system.WhenTerminated.Wait();
        }
    }
}