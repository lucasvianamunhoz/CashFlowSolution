using ConsolidatedService.Models;

namespace ConsolidatedService.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync(DateTime date);
    }

}
