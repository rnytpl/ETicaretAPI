using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        // TEntity type must has derive from a class
        // So we enforce T generic type to be a class
        DbSet<T> Table { get; }
    }
}
