using Personal.Core.Core.Models;
using Personal.Core.Repository.DataAccess;
using Personal.Core.Repository.Interfaces;
using Personal.Core.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Service.Managers
{
    public class EntranceManager : IEntranceService
    {
        private readonly IEntranceRepository _EntranceRepository;

        public EntranceManager(IEntranceRepository EntranceRepository)
        {
            _EntranceRepository = EntranceRepository;
        }

        public async Task ChangeStatusAllAsync(List<Entrance> t, bool status)
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
            await _EntranceRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Entrance t, bool status)
        {
            if (status)
            {
                t.Status = false;
            }
            else
            {
                t.Status = true;
            }
            await _EntranceRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(List<Entrance> t)
        {
            await _EntranceRepository.DeleteAllAsync(t);
        }

        public async Task DeleteAsync(Entrance t)
        {
            await _EntranceRepository.DeleteAsync(t);
        }

        public async Task<Entrance> GetByIdAsync(int id)
        {
            return await _EntranceRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Entrance t)
        {
            await _EntranceRepository.InsertAsync(t);
        }

        public async Task<List<Entrance>> ToListAsync()
        {
            return await _EntranceRepository.ToListAsync();
        }

        public async Task<List<Entrance>> ToListByFilterAsync(Expression<Func<Entrance, bool>> filter)
        {
            return await _EntranceRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Entrance t)
        {
            await _EntranceRepository.UpdateAsync(t);
        }
    }
}
