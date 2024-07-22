using MediatR;
using TransactionService.Models;
using TransactionService.Repositories;

namespace TransactionService.Queries
{
    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, IEnumerable<Transaction>>
    {
        private readonly ITransactionRepository _repository;

        public GetTransactionsQueryHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Transaction>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTransactionsAsync(request.Date);
        }
    }
}
