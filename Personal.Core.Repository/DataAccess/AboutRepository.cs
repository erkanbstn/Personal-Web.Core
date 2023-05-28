using Microsoft.EntityFrameworkCore;
using Personal.Core.Core.Models;
using Personal.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Repository.DataAccess
{
    public class AboutRepository : ModelRepository<About>, IAboutRepository
    {
        private readonly AppDbContext _appDbContext;
        public AboutRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> GetClickCountAsync()
        {
            return await _appDbContext.Abouts.Select(x => x.ClickCount).FirstOrDefaultAsync();
        }
    }
}
