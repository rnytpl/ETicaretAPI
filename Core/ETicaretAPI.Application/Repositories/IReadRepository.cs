using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
    
{
    // T is the entity type to define which entity we're going to perform EF core crud operations on database objects. BaseEntity class ensures that it is derived of a class.
    // Defines method signatures 
    // Handles read operations for entities
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
