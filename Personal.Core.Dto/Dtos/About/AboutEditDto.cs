using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Dto.Dtos.About
{
    public class AboutEditDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string GithubUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public int ClickCount { get; set; }
        public bool Status { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
