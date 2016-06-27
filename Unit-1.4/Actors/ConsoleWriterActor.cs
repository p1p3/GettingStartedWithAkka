using System;
using Akka.Actor;
using Unit_1._4.Messages.Error;
using Unit_1._4.Messages.Success;

namespace Unit_1._4.Actors
{
    internal class ConsoleWriterActor : TypedActor, IHandle<InputError>, IHandle<InputSuccess>, IHandle<string>
    {
        public void Handle(InputError message)
        {
            writeMessage(ConsoleColor.Red, message.Reason);
        }

        public void Handle(InputSuccess message)
        {
            writeMessage(ConsoleColor.Green, message.Reason);
        }

        private void writeMessage(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void Handle(string message)
        {
            Console.WriteLine(message);
        }
    }
}
