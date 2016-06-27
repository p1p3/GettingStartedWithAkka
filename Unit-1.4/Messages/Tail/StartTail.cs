using Akka.Actor;

namespace Unit_1._4.Messages.Tail
{
    public class StartTail
    {
        public StartTail(string filePath, IActorRef reporterActor)
        {
            FilePath = filePath;
            ReporterActor = reporterActor;
        }

        public string FilePath { get; private set; }

        public IActorRef ReporterActor { get; private set; }
    }
}