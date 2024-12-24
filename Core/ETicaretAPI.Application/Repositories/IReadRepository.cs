using ETicaretAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ETicaretAPI.Application.Repositories

{
    // T type determines which entity we're going to perform crud operations on using EF Core.
    // BaseEntity class ensures that it is derived of a class.

    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// tracking is the parameter that enables/disables tracking mechanism
        /// </summary>
        /// <param name="tracking"></param>
        /// <returns></returns>
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T,bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);

    }
}
