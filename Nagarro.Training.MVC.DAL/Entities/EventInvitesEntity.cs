using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Training.MVC.DAL
{
    public class EventInvitesEntity
    {
        [Key, Column(Order = 1)]
        public int EventID { get; set; }

        [Key, Column(Order = 2)]
        public string EmailID { get; set; }
    }
}
