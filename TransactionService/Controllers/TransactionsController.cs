using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransactionService.Commands;
using TransactionService.Queries;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactions([FromQuery] DateTime date)
    {
        var query = new GetTransactionsQuery { Date = date };
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
