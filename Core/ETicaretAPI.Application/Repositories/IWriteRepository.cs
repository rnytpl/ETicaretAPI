using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        // Async
        // Expects a model parameter of generic type T
        // Returns boolean
        Task<bool> AddAsync(T model);
        // Returns a list of datas of T generic type
        Task<bool> AddRangeAsync(List<T> datas);
        // Returns a boolean
        // Expects a model parameter of generic type T
        bool Remove(T model);
        // Retruns true or false
        // Expects a list of datas parameter of generic type T
        bool RemoveRange(List<T> datas);
        // Expects an id of string
        // Returns a boolean
        Task<bool> RemoveAsync(string id);
        bool UpdateAsync(T model);
        Task<int> SaveAsync();

    }
}
