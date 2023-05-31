using Personal.Core.Core.Models;
using Personal.Core.Repository.Interfaces;
using Personal.Core.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Service.Managers
{
    public class ManagerManager : IManagerService
    {
        private readonly IManagerRepository _ManagerRepository;

        public ManagerManager(IManagerRepository ManagerRepository)
        {
            _ManagerRepository = ManagerRepository;
        }

        public async Task ChangeStatusAllAsync(List<Manager> t, bool status)
        {
            if (status)
            {
                t.ForEach(b =>
                {
                    b.Status = false;
                });
            }
            else
            {
                t.ForEach(b =>
                {
                    b.Status = true;
                });
            }
            await _ManagerRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Manager t, bool status)
        {
            if (status)
            {
                t.Status = false;
            }
            else
            {
                t.Status = true;
            }
            await _ManagerRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(string tableName)
        {
            await _ManagerRepository.DeleteAllAsync(tableName);
        }

        public async Task DeleteAsync(Manager t)
        {
            await _ManagerRepository.DeleteAsync(t);
        }

        public async Task<Manager> GetByIdAsync(int id)
        {
            return await _ManagerRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Manager t)
        {
            await _ManagerRepository.InsertAsync(t);
        }

        public Task<Manager> SignInAsync(Manager manager)
        {
            return _ManagerRepository.SignInAsync(manager);
        }
        public async Task<ClaimsPrincipal> SignInWithClaimAsync(Manager manager)
        {
            var user = await SignInAsync(manager);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };
            var userIdentity = new ClaimsIdentity(claims, "SignIn");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
            return claimsPrincipal;
        }
        public async Task<List<Manager>> ToListAsync()
        {
            return await _ManagerRepository.ToListAsync();
        }

        public async Task<List<Manager>> ToListByFilterAsync(Expression<Func<Manager, bool>> filter)
        {
            return await _ManagerRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Manager t)
        {
            await _ManagerRepository.UpdateAsync(t);
        }
    }
}
