using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories.CompletedOrder
{
    public class CompletedOrderWriteRepository : WriteRepository<Domain.Entities.CompletedOrder>, ICompletedOrderWriteRepository
    {
        public CompletedOrderWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
