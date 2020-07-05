using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.Training.MVC.BookReadingEvent.Models
{
    public class SeprateEventsOnDate
    {
        public IList<EventViewModel> PastEvents = new List<EventViewModel>();
        public IList<EventViewModel> FutureEvents = new List<EventViewModel>();


        public static SeprateEventsOnDate SeprateEvents(IList<EventViewModel> eventViewModels)
        {
            SeprateEventsOnDate seprateEventsOnDate = new SeprateEventsOnDate();
            foreach (var entry in eventViewModels)
            {
                if (DateTime.Compare(entry.Date, DateTime.Now) >= 0)
                {
                    seprateEventsOnDate.FutureEvents.Add(entry);
                }
                else
                {
                    seprateEventsOnDate.PastEvents.Add(entry);
                }
            }
            return seprateEventsOnDate;
        }
    }
}
