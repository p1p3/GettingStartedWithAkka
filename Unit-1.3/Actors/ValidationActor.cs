using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace Unit_1._3.Actors
{
    public class ValidationActor : TypedActor, IHandle<string>
    {
        private readonly IActorRef _consoleWriterActor;

        public ValidationActor(IActorRef consoleWriterActor)
        {
            _consoleWriterActor = consoleWriterActor;
        }


        public void Handle(string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                // signal that the user needs to supply an input
                _consoleWriterActor.Tell(new Messages.Error.NullInputError("No input received."));
            }
            else
            {
                var valid = IsValid(msg);
                if (valid)
                {
                    // send success to console writer
                    _consoleWriterActor.Tell(new Messages.Success.InputSuccess("Thank you! Message was valid."));
                }
                else
                {
                    // signal that input was bad
                    _consoleWriterActor.Tell(new Messages.Error.ValidationError("Invalid: input had odd number of characters."));
                }
            }

            // tell sender to continue doing its thing
            // (whatever that may be, this actor doesn't care)
            Sender.Tell(new Messages.Neutral.ContinueProcessing());
        }

        /// <summary>
        /// Determines if the message received is valid.
        /// Checks if number of chars in message received is even.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private static bool IsValid(string msg)
        {
            var valid = msg.Length % 2 == 0;
            return valid;
        }
    }
}
