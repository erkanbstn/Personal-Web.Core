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
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageRepository _LanguageRepository;

        public LanguageManager(ILanguageRepository LanguageRepository)
        {
            _LanguageRepository = LanguageRepository;
        }

        public async Task ChangeStatusAllAsync(List<Language> t, bool status)
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
            await _LanguageRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Language t, bool status)
        {
            if (status)
            {
                t.Status = false;
            }
            else
            {
                t.Status = true;
            }
            await _LanguageRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(string tableName)
        {
            await _LanguageRepository.DeleteAllAsync(tableName);
        }

        public async Task DeleteAsync(Language t)
        {
            await _LanguageRepository.DeleteAsync(t);
        }

        public async Task<Language> GetByIdAsync(int id)
        {
            return await _LanguageRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Language t)
        {
            await _LanguageRepository.InsertAsync(t);
        }

        public async Task<List<Language>> ToListAsync()
        {
            return await _LanguageRepository.ToListAsync();
        }

        public async Task<List<Language>> ToListByFilterAsync(Expression<Func<Language, bool>> filter)
        {
            return await _LanguageRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Language t)
        {
            await _LanguageRepository.UpdateAsync(t);
        }
    }
}
