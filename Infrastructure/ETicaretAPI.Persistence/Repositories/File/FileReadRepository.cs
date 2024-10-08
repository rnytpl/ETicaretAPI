﻿using P = ETicaretAPI.Domain.Entities;
using ETicaretAPI.Application.Repositories.File;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.File
{
    public class FileReadRepository : ReadRepository<P.File>, IFileReadRepository
    {
        public FileReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
