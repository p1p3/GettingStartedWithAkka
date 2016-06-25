using System;
using Akka.Actor;

namespace Unit_1.Actors
{
    internal class ConsoleReaderActor : UntypedActor
    {
        public const string ExitCommand = "exit";
        private readonly IActorRef _consoleWriterActor;

        public ConsoleReaderActor(IActorRef consoleWriterActor)
        {
            _consoleWriterActor = consoleWriterActor;
        }

        protected override void OnReceive(object message)
        {
            var read = Console.ReadLine();
            if (!string.IsNullOrEmpty(read) && string.Equals(read, ExitCommand, StringComparison.OrdinalIgnoreCase))
            {
                Context.System.Terminate();
                return;
            }

            var userInput = new ConsoleInput(read);
            _consoleWriterActor.Tell(userInput);

            Self.Tell("continue");
        }
    }
}