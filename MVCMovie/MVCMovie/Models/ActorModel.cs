using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVCMovie.Models
{
    public class ActorModel
    {
        [Display(Name = "Actor Name")]
        [Required(ErrorMessage = "You need to provide actor name.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets and allowed.")]
        public string ActorName { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "You need to select gender.")]
        public string Sex { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Please provide actor's date of birth.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Please provide some information on the actor.")]
        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }
    }
}