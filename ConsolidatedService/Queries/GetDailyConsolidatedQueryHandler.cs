using ConsolidatedService.Models;
using ConsolidatedService.Repositories;
using MediatR;

namespace ConsolidatedService.Queries
{
    public class GetDailyConsolidatedQueryHandler : IRequestHandler<GetDailyConsolidatedQuery, DailyConsolidated>
    {
        private readonly ITransactionRepository _repository;

        public GetDailyConsolidatedQueryHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<DailyConsolidated> Handle(GetDailyConsolidatedQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _repository.GetTransactionsAsync(request.Date);

            var totalCredits = transactions.Where(t => t.Type == "Credit").Sum(t => t.Amount);
            var totalDebits = transactions.Where(t => t.Type == "Debit").Sum(t => t.Amount);

            return new DailyConsolidated
            {
                Date = request.Date,
                TotalCredits = totalCredits,
                TotalDebits = totalDebits,
                Balance = totalCredits - totalDebits
            };
        }
    }
}
