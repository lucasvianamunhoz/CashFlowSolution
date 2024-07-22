using MediatR;
using TransactionService.Models;
using TransactionService.Repositories;

namespace TransactionService.Commands
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, bool>
    {
        private readonly ITransactionRepository _repository;

        public CreateTransactionCommandHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction
            {
                Amount = request.Amount,
                Type = request.Type,
                Date = DateTime.UtcNow
            };

            return await _repository.AddTransactionAsync(transaction);
        }
    }
}
