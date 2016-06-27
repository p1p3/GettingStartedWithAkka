using System.IO;
using Akka.Actor;
using Unit_1._4.Actors.TailCoordinator;
using Unit_1._4.Messages.Error;
using Unit_1._4.Messages.Neutral;
using Unit_1._4.Messages.Success;
using Unit_1._4.Messages.Tail;

namespace Unit_1._4.Actors
{
    public class FileValidatorActor : TypedActor, IHandle<string>
    {
        private readonly IActorRef _consoleWriterActor;
        private readonly IActorRef _tailCoordinatorActor;

        public FileValidatorActor(IActorRef consoleWriterActor, IActorRef tailCoordinatorActor)
        {
            _consoleWriterActor = consoleWriterActor;
            _tailCoordinatorActor = tailCoordinatorActor;
        }


        public void Handle(string fileUriMsg)
        {
            if (string.IsNullOrEmpty(fileUriMsg))
            {
                _consoleWriterActor.Tell(new NullInputError("Input Was blank. Please try again.\n"));
                Sender.Tell(new ContinueProcessing());
            }
            else
            {
                var isValid = IsFileUri(fileUriMsg);
                if (isValid)
                {
                    var validMsg = $"Starting processing for {fileUriMsg}";
                    _consoleWriterActor.Tell(new InputSuccess(validMsg));
                    _tailCoordinatorActor.Tell(new StartTail(fileUriMsg, _consoleWriterActor));
                }
                else
                {
                    var invalidMsg = $"{fileUriMsg} is not an existing URI on disk.";
                    _consoleWriterActor.Tell(new ValidationError(invalidMsg));
                    Sender.Tell(new ContinueProcessing());
                }

            }
        }

        /// <summary>
        /// Checks if file exists at path provided by user.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool IsFileUri(string path)
        {
            return File.Exists(path);
        }
    }
}
