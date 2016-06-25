using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1.Actors
{
    internal class ConsoleInput
    {
        public ConsoleInput(string message)
        {
            Message = message;
        }

        public string  Message { get; private set; }

    }
}
