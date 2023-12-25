using Application.Features.LoyaltyProgramSubscriptions.Commands.Create;
using Application.Features.LoyaltyProgramSubscriptions.Commands.Delete;
using Application.Features.LoyaltyProgramSubscriptions.Commands.Update;
using Application.Features.LoyaltyProgramSubscriptions.Queries.GetById;
using Application.Features.LoyaltyProgramSubscriptions.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoyaltyProgramSubscriptionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLoyaltyProgramSubscriptionCommand createLoyaltyProgramSubscriptionCommand)
    {
        CreatedLoyaltyProgramSubscriptionResponse response = await Mediator.Send(createLoyaltyProgramSubscriptionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLoyaltyProgramSubscriptionCommand updateLoyaltyProgramSubscriptionCommand)
    {
        UpdatedLoyaltyProgramSubscriptionResponse response = await Mediator.Send(updateLoyaltyProgramSubscriptionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedLoyaltyProgramSubscriptionResponse response = await Mediator.Send(new DeleteLoyaltyProgramSubscriptionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdLoyaltyProgramSubscriptionResponse response = await Mediator.Send(new GetByIdLoyaltyProgramSubscriptionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLoyaltyProgramSubscriptionQuery getListLoyaltyProgramSubscriptionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLoyaltyProgramSubscriptionListItemDto> response = await Mediator.Send(getListLoyaltyProgramSubscriptionQuery);
        return Ok(response);
    }
}