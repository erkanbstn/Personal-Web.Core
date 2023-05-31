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
    public class ContactManager : IContactService
    {
        private readonly IContactRepository _ContactRepository;

        public ContactManager(IContactRepository ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }

        public async Task ChangeStatusAllAsync(List<Contact> t, bool status)
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
            await _ContactRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Contact t, bool status)
        {
            if (status)
            {
                t.Status = false;
            }
            else
            {
                t.Status = true;
            }
            await _ContactRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(string tableName)
        {
            await _ContactRepository.DeleteAllAsync(tableName);
        }

        public async Task DeleteAsync(Contact t)
        {
            await _ContactRepository.DeleteAsync(t);
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _ContactRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Contact t)
        {
            await _ContactRepository.InsertAsync(t);
        }

        public async Task<List<Contact>> ToListAsync()
        {
            return await _ContactRepository.ToListAsync();
        }

        public async Task<List<Contact>> ToListByFilterAsync(Expression<Func<Contact, bool>> filter)
        {
            return await _ContactRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Contact t)
        {
            await _ContactRepository.UpdateAsync(t);
        }
    }
}
