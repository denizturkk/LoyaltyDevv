using Application.Features.LoyaltyPrograms.Commands.Create;
using Application.Features.LoyaltyPrograms.Commands.Delete;
using Application.Features.LoyaltyPrograms.Commands.Update;
using Application.Features.LoyaltyPrograms.Queries.GetById;
using Application.Features.LoyaltyPrograms.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoyaltyProgramsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLoyaltyProgramCommand createLoyaltyProgramCommand)
    {
        CreatedLoyaltyProgramResponse response = await Mediator.Send(createLoyaltyProgramCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLoyaltyProgramCommand updateLoyaltyProgramCommand)
    {
        UpdatedLoyaltyProgramResponse response = await Mediator.Send(updateLoyaltyProgramCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedLoyaltyProgramResponse response = await Mediator.Send(new DeleteLoyaltyProgramCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdLoyaltyProgramResponse response = await Mediator.Send(new GetByIdLoyaltyProgramQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLoyaltyProgramQuery getListLoyaltyProgramQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLoyaltyProgramListItemDto> response = await Mediator.Send(getListLoyaltyProgramQuery);
        return Ok(response);
    }
}