using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Training.MVC.Shared
{
    public class DALException : Exception
    {
        public DALException(string Message) :base(Message)
        {

        }
    }
}
