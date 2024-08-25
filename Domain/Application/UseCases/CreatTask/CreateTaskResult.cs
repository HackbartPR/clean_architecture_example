using Domain.Application.DTOs.Entities;

namespace Domain.Application.UseCases.CreatTask;

public class CreateTaskResult(Guid guid, TaskDTO task)
{
	public Guid UserId { get; set; } = guid;

	public TaskDTO Task { get; set; } = task;
}
