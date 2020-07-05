using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Training.MVC.Shared
{
    public class UserDTO
    {
        public int UserID { get; set; }

        public string EmailID { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }
    }
}
