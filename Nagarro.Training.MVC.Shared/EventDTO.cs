using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Training.MVC.Shared
{
    public enum Type
    {
        Public,
        Private
    }

    public class EventDTO
    {
        public int EventID { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public DateTime? Starttime { get; set; } //dropdown(from 00:00 to 2300)

        public Type Type { get; set; }=Type.Public;       //Public/Private 

        public float? Durationinhours { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        public string EventInvites { get; set; }

        public int PeopleInvited { get; set; }

        public int UserID { get; set; }
    }
}
