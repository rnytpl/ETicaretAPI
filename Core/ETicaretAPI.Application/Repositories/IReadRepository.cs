using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    /// <summary>
    /// IReadRepository inherits from IRepository interface and both expect an entity type of T
    /// so that EF can recognize the type of entity it should operate on
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// All Read queries take a lambda expression and a tracking parameters
        /// By default, change tracking is set to true
        /// However, if a user decides to disable EF ChangeTracking mechanism, 
        /// they can do so by giving a boolean type of false as second parameter to the associated Query thus disable changetracking mechanism
        /// </summary>
        /// <param name="tracking"></param>
        /// <returns></returns>
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetById(string id, bool tracking = true);

    }
}