using System;
using Akka.Actor;
using GettingStartedWithAkka.Actors;
using GettingStartedWithAkka.Model;

namespace GettingStartedWithAkka
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var system = ActorSystem.Create("MySystem");
            var greeter = system.ActorOf<GreetingActor>("greeter");

            greeter.Tell(new Greet("World"));

            Console.ReadLine();
        }
    }
}