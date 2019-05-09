using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class MovieModel
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Plot { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Producer { get; set; }
        public string ImgPath { get; set; }
        public string Actors { get; set; }
    }
}
