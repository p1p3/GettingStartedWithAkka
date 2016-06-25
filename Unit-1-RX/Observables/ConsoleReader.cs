using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Unit_1_RX.Models;

namespace Unit_1_RX.Observables
{
    internal class ConsoleReader : IObservable<ConsoleInput>
    {
        #region IObservable Implenetation
        public IDisposable Subscribe(IObserver<ConsoleInput> observer)
        {
            var subscription = GetInput().ToObservable(NewThreadScheduler.Default).Subscribe(observer);
            return subscription;
        }
        #endregion

        private static IEnumerable<ConsoleInput> GetInput()
        {
            while (true)
            {
                var enteredText = Console.ReadLine();
                var userInput = new ConsoleInput(enteredText);
                yield return userInput;
            }
        }
    }
}
