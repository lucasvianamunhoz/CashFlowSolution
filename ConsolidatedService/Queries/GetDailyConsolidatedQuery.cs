using ConsolidatedService.Models;
using MediatR;

namespace ConsolidatedService.Queries
{
    public class GetDailyConsolidatedQuery : IRequest<DailyConsolidated>
    {
        public DateTime Date { get; set; }
    }

}
