using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Core.Models
{
    public class Education : BaseModel
    {
        public string Date { get; set; }
        public string Graduation { get; set; }
        public string Degree { get; set; }
        public string Address { get; set; }
        public string Content { get; set; }

    }
}
