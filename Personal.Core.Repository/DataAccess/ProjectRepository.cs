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
    public class ProjectRepository : ModelRepository<Project>, IProjectRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProjectRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Project>> OrderByDescendingProject()
        {
            return await _appDbContext.Projects.OrderByDescending(x => x.Id).Where(x => x.Status == true).ToListAsync();

        }
    }
}
