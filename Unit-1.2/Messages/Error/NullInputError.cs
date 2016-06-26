using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1._2.Messages.Error
{
    public class NullInputError:InputError
    {
        public NullInputError(string reason) : base(reason)
        {
        }
    }
}
