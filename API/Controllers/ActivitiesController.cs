using API.Application.Activities.Commands;
using API.Application.Activities.Queries;
using API.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities() => await mediator.Send(new GetActivityList.Query());

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(string id) => await mediator.Send(new GetActivityDetails.Query { Id = id });

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity) => await mediator.Send(new CreateActivity.Command { Activity = activity });

    [HttpPut]
    public async Task<ActionResult> EditActivity(Activity activity)
    {
        await mediator.Send(new EditActivity.Command { Activity = activity });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        await mediator.Send(new DeleteActivity.Command { Id = id });
        return Ok();
    }
}
