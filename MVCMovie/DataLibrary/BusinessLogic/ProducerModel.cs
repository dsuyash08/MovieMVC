using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class ProducerModel
    {
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public string Sex { get; set; }
        public DateTime DOB { get; set; }
        public string Bio { get; set; }
    }
}
