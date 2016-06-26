using System;
using Akka.Actor;
using Unit_1.Model;

namespace Unit_1.Actors
{
    internal class ConsoleWriterActor : TypedActor, IHandle<ConsoleInput>
    {
        public void Handle(ConsoleInput consoleInput)
        {
            var msg = consoleInput.Message;

            // if message has even # characters, display in red; else, green
            var even = msg.Length % 2 == 0;
            var color = even ? ConsoleColor.Red : ConsoleColor.Green;
            var alert = even ? "Your string had an even # of characters.\n" : "Your string had an odd # of characters.\n";
            Console.ForegroundColor = color;
            Console.WriteLine(alert);
            Console.ResetColor();
        }
    }
}
