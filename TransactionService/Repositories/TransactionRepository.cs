using Microsoft.EntityFrameworkCore;
using TransactionService.Data;
using TransactionService.Models;

namespace TransactionService.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(DateTime date)
        {
            return await _context.Transactions
                .Where(t => t.Date.Date == date.Date)
                .ToListAsync();
        }
    }

}
