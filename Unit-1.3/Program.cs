using Akka.Actor;
using Unit_1._3.Actors;

namespace Unit_1._3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var system = ActorSystem.Create("ActorSystem");


            var consoleWriterProps = Props.Create<ConsoleWriterActor>();
            var consoleWriterActor = system.ActorOf(consoleWriterProps,
            "consoleWriterActor");

            var validationActorProps = Props.Create(
                () => new ValidationActor(consoleWriterActor));
            var validationActor = system.ActorOf(validationActorProps,
            "validationActor");
            
            var consoleReaderProps = Props.Create<ConsoleReaderActor>(validationActor);
            var consoleReaderActor = system.ActorOf(consoleReaderProps,
                "consoleReaderActor");

     
            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);
            system.WhenTerminated.Wait();
        }
    }
}