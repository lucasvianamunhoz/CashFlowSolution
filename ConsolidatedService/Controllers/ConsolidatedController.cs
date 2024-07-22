using ConsolidatedService.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConsolidatedService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsolidatedController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsolidatedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDailyConsolidated([FromQuery] DateTime date)
        {
            var query = new GetDailyConsolidatedQuery { Date = date };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }


}
