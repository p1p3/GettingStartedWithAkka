using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_1._2.Messages.Error
{
    public  class ValidationError:InputError
    {
        public ValidationError(string reason) : base(reason)
        {
        }
    }
}
