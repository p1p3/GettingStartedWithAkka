using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Unit_1._4.Actors;
using Unit_1._4.Actors.TailCoordinator;

namespace Unit_1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("ActorSystem");


            var consoleWriterProps = Props.Create<ConsoleWriterActor>();
            var consoleWriterActor = system.ActorOf(consoleWriterProps, "consoleWriterActor");

            var tailCoordinatorProps = Props.Create(() => new TailCoordinatorActor());
            var tailCoordinatorActor = system.ActorOf(tailCoordinatorProps, "tailCoordinatorActor");

            var validationActorProps = Props.Create(
                () => new FileValidatorActor(consoleWriterActor, tailCoordinatorActor));
            var validationActor = system.ActorOf(validationActorProps, "validationActor");


            var consoleReaderProps = Props.Create<ConsoleReaderActor>(validationActor);
            var consoleReaderActor = system.ActorOf(consoleReaderProps, "consoleReaderActor");


            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);
            system.WhenTerminated.Wait();
        }
    }
}
