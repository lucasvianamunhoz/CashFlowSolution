using ConsolidatedService.Data;
using ConsolidatedService.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsolidatedService.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(DateTime date)
        {
            return await _context.Transactions
                .Where(t => t.Date.Date == date.Date)
                .ToListAsync();
        }
    }

}
