using System.Linq.Expressions;

namespace Personal.Core.Service.Services
{
    public interface IRepositoryService<T> where T : class
    {
        Task InsertAsync(T t);
        Task DeleteAsync(T t);
        Task DeleteAllAsync(string tableName);
        Task ChangeStatusAsync(T t, bool status);
        Task ChangeStatusAllAsync(List<T> t, bool status);
        Task UpdateAsync(T t);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ToListAsync();
        Task<List<T>> ToListByFilterAsync(Expression<Func<T, bool>> filter);

    }
}
