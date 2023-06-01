using Personal.Core.Core.Models;
using Personal.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Service.Services
{
    public interface IManagerService : IRepositoryService<Manager>
    {
        Task<Manager> SignInAsync(Manager manager);
        Task<ClaimsPrincipal> SignInWithClaimAsync(Manager manager);
        Task<Manager> GetByNameAsync(string userName);

    }
}
