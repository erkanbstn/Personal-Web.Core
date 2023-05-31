using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Dto.Dtos.Entrance
{
    public class EntranceEditDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Detail { get; set; }
        public IFormFile Picture { get; set; }
        public bool Status { get; set; }
    }
}
