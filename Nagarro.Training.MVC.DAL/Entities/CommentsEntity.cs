using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nagarro.Training.MVC.DAL
{
    public class CommentsEntity
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }
        
        public int EventID { get; set; }
        
        //public int UserID { get; set; }

        public DateTime PostDate { get; set; }

        public string Comment { get; set; }
    }
}
