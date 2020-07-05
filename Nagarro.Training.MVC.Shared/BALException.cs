using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Training.MVC.Shared
{
    public class BALException : Exception
    {
        public BALException(string Message) :base(Message)
        {

        }
    }
}
