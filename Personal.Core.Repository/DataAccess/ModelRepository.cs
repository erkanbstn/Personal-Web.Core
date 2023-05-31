using Microsoft.EntityFrameworkCore;
using Personal.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.Repository.DataAccess
{
    public class ModelRepository<T> : IModelRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        DbSet<T> _object;
        public ModelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _object = _appDbContext.Set<T>();
        }

        public async Task ChangeStatusAllAsync(List<T> t)
        {
            _object.UpdateRange(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task ChangeStatusAsync(T t)
        {
            _object.Update(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(string tableName)
        {
            await _appDbContext.Database.ExecuteSqlRawAsync($"Truncate Table {tableName}");
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T t)
        {
            _object.Remove(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _object.FindAsync(id);
        }

        public async Task InsertAsync(T t)
        {
            await _object.AddAsync(t);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<List<T>> ToListAsync()
        {
            return await _object.ToListAsync();
        }

        public async Task<List<T>> ToListByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _object.Where(filter).ToListAsync();
        }

        public async Task UpdateAsync(T t)
        {
            _object.Update(t);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
