using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _ctx;

        public TransferRepository(TransferDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddAsync(TransferLog transferLog)
        {
            await _ctx.AccountTransfers.AddAsync(transferLog);
            await _ctx.SaveChangesAsync();
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _ctx.AccountTransfers;
        }
    }
}
