using Application.Features.RewardTransactions.Commands.Create;
using Application.Features.RewardTransactions.Commands.Delete;
using Application.Features.RewardTransactions.Commands.Update;
using Application.Features.RewardTransactions.Queries.GetById;
using Application.Features.RewardTransactions.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RewardTransactionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRewardTransactionCommand createRewardTransactionCommand)
    {
        CreatedRewardTransactionResponse response = await Mediator.Send(createRewardTransactionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRewardTransactionCommand updateRewardTransactionCommand)
    {
        UpdatedRewardTransactionResponse response = await Mediator.Send(updateRewardTransactionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedRewardTransactionResponse response = await Mediator.Send(new DeleteRewardTransactionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdRewardTransactionResponse response = await Mediator.Send(new GetByIdRewardTransactionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRewardTransactionQuery getListRewardTransactionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRewardTransactionListItemDto> response = await Mediator.Send(getListRewardTransactionQuery);
        return Ok(response);
    }
}