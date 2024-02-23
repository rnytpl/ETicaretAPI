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
        /// <summary>
        /// Takes a type of T to access table of type T in database
        /// </summary>
        DbSet<T> Table {  get; }
    }
}
