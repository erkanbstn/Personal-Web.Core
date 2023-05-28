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
    public class ManagerRepository : ModelRepository<Manager>, IManagerRepository
    {
        private readonly AppDbContext _appDbContext;
        public ManagerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Manager> SignInAsync(Manager manager)
        {
            return await _appDbContext.Managers.Where(x => x.Status == true).FirstOrDefaultAsync(x => x.UserName == manager.UserName && x.Password == manager.Password);
        }
    }
}
