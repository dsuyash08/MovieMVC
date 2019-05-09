using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMovie.Models
{
    public class MovieModel
    {
        public int MovieId { get; set; }

        [Display(Name ="Movie Name")]
        [Required(ErrorMessage = "You need to provide movie name.")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string MovieName { get; set; }

        [Required(ErrorMessage = "You need to provide plot details.")]
        [DataType(DataType.MultilineText)]
        public string Plot { get; set; }

        [Display(Name ="Release Date")]
        [Required(ErrorMessage ="You need to provide release date.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }        

        public string ImgPath { get; set; }

        public string Producer { get; set; }

        public string Actors { get; set; }

        [Display(Name = "Movie Poster")]
        public HttpPostedFileBase ImageFile { get; set; } 

        public IEnumerable<SelectListItem> ActorList { get; set; }

        [Required(ErrorMessage = "Please select movie actors.")]
        [Display(Name = "Actors")]
        public IEnumerable<string> ActorNames { get; set; }

        public SelectList ProducerList { get; set; }

        [Required(ErrorMessage = "Please select movie producer.")]
        [Display(Name = "Producer")]
        public string SelectedProducer { get; set; }
    }
}