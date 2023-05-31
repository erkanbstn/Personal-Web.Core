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
    public class ExperienceManager : IExperienceService
    {
        private readonly IExperienceRepository _ExperienceRepository;

        public ExperienceManager(IExperienceRepository ExperienceRepository)
        {
            _ExperienceRepository = ExperienceRepository;
        }

        public async Task ChangeStatusAllAsync(List<Experience> t, bool status)
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
            await _ExperienceRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Experience t, bool status)
        {
            if (status)
            {
                t.Status = false;
            }
            else
            {
                t.Status = true;
            }
            await _ExperienceRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(string tableName)
        {
            await _ExperienceRepository.DeleteAllAsync(tableName);
        }

        public async Task DeleteAsync(Experience t)
        {
            await _ExperienceRepository.DeleteAsync(t);
        }

        public async Task<Experience> GetByIdAsync(int id)
        {
            return await _ExperienceRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Experience t)
        {
            await _ExperienceRepository.InsertAsync(t);
        }

        public async Task<List<Experience>> OrderByDescendingExperience()
        {
            return await _ExperienceRepository.OrderByDescendingExperience();
        }

        public async Task<List<Experience>> ToListAsync()
        {
            return await _ExperienceRepository.ToListAsync();
        }

        public async Task<List<Experience>> ToListByFilterAsync(Expression<Func<Experience, bool>> filter)
        {
            return await _ExperienceRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Experience t)
        {
            await _ExperienceRepository.UpdateAsync(t);
        }
    }
}
