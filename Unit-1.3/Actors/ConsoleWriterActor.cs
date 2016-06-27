using System;
using Akka.Actor;
using Unit_1._3.Messages.Error;
using Unit_1._3.Messages.Success;

namespace Unit_1._3.Actors
{
    internal class ConsoleWriterActor : TypedActor, IHandle<InputError>, IHandle<InputSuccess>
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
    }
}
