using Adapters.CrossCutting;
using Adapters.Interfaces;
using Domain.Application.Interfaces.UseCases;
using Domain.Application.UseCases.CreatTask;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web.Requests.Task;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController(ICreateTaskPresenter createTaskPresenter, ITaskUseCases taskUseCases) : ControllerBase
{
	private readonly ICreateTaskPresenter _createTaskPresenter = createTaskPresenter ?? throw new ArgumentNullException(nameof(createTaskPresenter));
	private readonly ITaskUseCases _taskUseCases = taskUseCases ?? throw new ArgumentNullException(nameof(taskUseCases));

	[HttpPost("/{userId}")]
	public async Task<IActionResult> Create([FromRoute] Guid userId, [FromBody] CreateTaskRequest request, CancellationToken cancellationToken = default)
	{
		try
		{
			CreateTaskCommand command = new CreateTaskCommand(userId, request.Title, request.Description, request.DueDate, request.Priority, request.TagsId);
			WebBaseResponse<CreateTaskResult?> result = await _createTaskPresenter.Create(command, cancellationToken);

			return result.StatusCode switch
			{
				HttpStatusCode.OK => Ok(result.Data),
				HttpStatusCode.Created => CreatedAtAction(nameof(Create), new { id = result.Data }, result.Data),
				HttpStatusCode.BadRequest => BadRequest(result.Message),
				HttpStatusCode.NotFound => NotFound(result.Message),
				HttpStatusCode.Unauthorized => Unauthorized(result.Message),
				HttpStatusCode.Forbidden => Forbid(),
				_ => StatusCode((int)result.StatusCode, result.Message)
			};
		}
		catch (Exception ex)
		{
			return BadRequest(ex);
		}
	}
}
