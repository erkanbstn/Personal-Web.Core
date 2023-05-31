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
    public class SkillManager : ISkillService
    {
        private readonly ISkillRepository _SkillRepository;

        public SkillManager(ISkillRepository SkillRepository)
        {
            _SkillRepository = SkillRepository;
        }

        public async Task ChangeStatusAllAsync(List<Skill> t, bool status)
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
            await _SkillRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Skill t, bool status)
        {
            if (status)
            {
                t.Status = false;
            }
            else
            {
                t.Status = true;
            }
            await _SkillRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(string tableName)
        {
            await _SkillRepository.DeleteAllAsync(tableName);
        }

        public async Task DeleteAsync(Skill t)
        {
            await _SkillRepository.DeleteAsync(t);
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            return await _SkillRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Skill t)
        {
            await _SkillRepository.InsertAsync(t);
        }

        public async Task<List<Skill>> ToListAsync()
        {
            return await _SkillRepository.ToListAsync();
        }

        public async Task<List<Skill>> ToListByFilterAsync(Expression<Func<Skill, bool>> filter)
        {
            return await _SkillRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Skill t)
        {
            await _SkillRepository.UpdateAsync(t);
        }
    }
}
