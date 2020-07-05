using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Training.MVC.Shared
{
    public class CommentsDTO
    {
        public int CommentID { get; set; }

        public int EventID { get; set; }
        
        //public string UserID { get; set; }

        public DateTime PostDate { get; set; }

        public string Comment { get; set; }
    }
}
