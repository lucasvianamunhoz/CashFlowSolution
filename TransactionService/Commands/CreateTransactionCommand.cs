using MediatR;

namespace TransactionService.Commands
{
    public class CreateTransactionCommand : IRequest<bool>
    {
        public decimal Amount { get; set; }
        public string Type { get; set; } // Credit or Debit
    }
}
