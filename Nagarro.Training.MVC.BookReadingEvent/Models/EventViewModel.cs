using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nagarro.Training.MVC.BookReadingEvent.Models
{
    public enum Type
    {
        Public,
        Private
    }

    public class EventViewModel
    {
        public int EventID { get; set; }
        
        [Required(ErrorMessage = "Field is Required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field is Required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Field is Required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Field is Required.")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Starttime { get; set; }

        public Type Type { get; set; }       

        [Range(1,4,ErrorMessage ="Duration must be between 1 to 4 Hours")]
        [Display(Name = "Duration in Hours")]
        public float? Durationinhours { get; set; }

        [MaxLength(50,ErrorMessage ="Length of field can't exceed more than 50 words.")]
        public string Description { get; set; }

        [MaxLength(500, ErrorMessage = "Length of field can't exceed more than 500 words.")]
        [Display(Name = "Other Details")]
        public string OtherDetails { get; set; }

        [Display(Name = "Invited People")]
        public string EventInvites { get; set; }

        [Display(Name = "No of People invited ")]
        public int PeopleInvited { get; set; }

        [Display(Name = "Creator ID")]
        public int UserID { get; set; }
    }
}
