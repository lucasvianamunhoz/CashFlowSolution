using MediatR;
using TransactionService.Models;

namespace TransactionService.Queries
{
    public class GetTransactionsQuery : IRequest<IEnumerable<Transaction>>
    {
        public DateTime Date { get; set; }
    }
}
