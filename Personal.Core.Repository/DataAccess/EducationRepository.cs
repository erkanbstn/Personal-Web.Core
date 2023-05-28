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
    public class EducationRepository : ModelRepository<Education>, IEducationRepository
    {
        private readonly AppDbContext _appDbContext;
        public EducationRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Education>> OrderByDescendingEducation()
        {
            return await _appDbContext.Educations.OrderByDescending(x => x.Id).Where(x => x.Status == true).ToListAsync();
        }
    }
}
