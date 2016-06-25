using System;
using Akka.Actor;
using GettingStartedWithAkka.Model;

namespace GettingStartedWithAkka.Actors
{
    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {
            Receive<Greet>(greet => Console.WriteLine("Hello {0}", greet.Who));
        }
    }
}