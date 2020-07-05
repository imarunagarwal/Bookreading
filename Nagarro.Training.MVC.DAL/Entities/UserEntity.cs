using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Training.MVC.DAL
{
    public class UserEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string EmailID { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }
    }
}
