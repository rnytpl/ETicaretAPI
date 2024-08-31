using P = ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Application.Repositories.File;


namespace ETicaretAPI.Persistence.Repositories.File
{
    public class FileWriteRepository : WriteRepository<P.File>, IFileWriteRepository
    {
        public FileWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
