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
    public class ExperienceRepository : ModelRepository<Experience>, IExperienceRepository
    {
        private readonly AppDbContext _appDbContext;
        public ExperienceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Experience>> OrderByDescendingExperience()
        {
            return await _appDbContext.Experiences.OrderByDescending(x => x.Id).Where(x => x.Status == true).ToListAsync();
        }
    }
}
