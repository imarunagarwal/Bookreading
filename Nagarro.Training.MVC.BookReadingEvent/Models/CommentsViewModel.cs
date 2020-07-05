using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.Training.MVC.BookReadingEvent.Models
{
    public class CommentsViewModel
    {
        public int CommentID { get; set; }

        public int EventID { get; set; }

        public DateTime PostDate { get; set; }

        public string Comment { get; set; }
    }
}