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
    public class ProjectManager : IProjectService
    {
        private readonly IProjectRepository _ProjectRepository;

        public ProjectManager(IProjectRepository ProjectRepository)
        {
            _ProjectRepository = ProjectRepository;
        }

        public async Task ChangeStatusAllAsync(List<Project> t, bool status)
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
            await _ProjectRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Project t, bool status)
        {
            if (status)
            {
                t.Status = false;
            }
            else
            {
                t.Status = true;
            }
            await _ProjectRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(string tableName)
        {
            await _ProjectRepository.DeleteAllAsync(tableName);
        }

        public async Task DeleteAsync(Project t)
        {
            await _ProjectRepository.DeleteAsync(t);
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _ProjectRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Project t)
        {
            await _ProjectRepository.InsertAsync(t);
        }

        public async Task<List<Project>> OrderByDescendingProject()
        {
            return await _ProjectRepository.OrderByDescendingProject();
        }

        public async Task<List<Project>> ToListAsync()
        {
            return await _ProjectRepository.ToListAsync();
        }

        public async Task<List<Project>> ToListByFilterAsync(Expression<Func<Project, bool>> filter)
        {
            return await _ProjectRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Project t)
        {
            await _ProjectRepository.UpdateAsync(t);
        }
    }
}
