using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Core.Models
{
    public class About : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string GithubUrl { get; set; }
        public string LinkedInUrl { get; set; }

    }
}
