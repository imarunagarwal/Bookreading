using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nagarro.Training.MVC.BookReadingEvent.Models
{
    public class UserViewModel
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Field is Required.")]
        [Display(Name = "Email ID")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Enter a valid Email Address.")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Field is Required.")]
        [DataType(DataType.Password)]
        [MinLength(5)]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*[A-Za-z])(?=.*[@#$%^&+=]).*$",ErrorMessage ="The Password length must be minimum 5 and it must contain a special symbol.")]
        public string Password { get; set; }

        public string FullName { get; set; }
    }
}