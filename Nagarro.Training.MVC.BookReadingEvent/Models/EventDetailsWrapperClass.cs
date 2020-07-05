using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.Training.MVC.BookReadingEvent.Models
{
    public class EventDetailsWrapperClass
    {
        public EventViewModel eventViewModel;
        public IList<CommentsViewModel> commentsViewModels;

        public EventDetailsWrapperClass(EventViewModel eventViewModel,IList<CommentsViewModel> commentsViewModels)
        {
            this.eventViewModel = eventViewModel;
            this.commentsViewModels = commentsViewModels;
        }
    }
}