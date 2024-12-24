using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Application.Repositories
{
    /// <summary>
    /// IRepository must be of T type where type T derives from BaseEntity Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        // TEntity type must derive from a class
        // So we enforce T generic type to be a class of BaseEntity
        DbSet<T> Table { get; }
    }
}
