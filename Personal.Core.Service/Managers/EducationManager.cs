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
    public class EducationManager : IEducationService
    {
        private readonly IEducationRepository _EducationRepository;

        public EducationManager(IEducationRepository EducationRepository)
        {
            _EducationRepository = EducationRepository;
        }

        public async Task ChangeStatusAllAsync(List<Education> t, bool status)
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
            await _EducationRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Education t, bool status)
        {
            if (status)
            {
                t.Status = false;
            }
            else
            {
                t.Status = true;
            }
            await _EducationRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(string tableName)
        {
            await _EducationRepository.DeleteAllAsync(tableName);
        }

        public async Task DeleteAsync(Education t)
        {
            await _EducationRepository.DeleteAsync(t);
        }

        public async Task<Education> GetByIdAsync(int id)
        {
            return await _EducationRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Education t)
        {
            await _EducationRepository.InsertAsync(t);
        }

        public async Task<List<Education>> OrderByDescendingEducation()
        {
            return await _EducationRepository.OrderByDescendingEducation();
        }

        public async Task<List<Education>> ToListAsync()
        {
            return await _EducationRepository.ToListAsync();
        }

        public async Task<List<Education>> ToListByFilterAsync(Expression<Func<Education, bool>> filter)
        {
            return await _EducationRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Education t)
        {
            await _EducationRepository.UpdateAsync(t);
        }
    }
}
