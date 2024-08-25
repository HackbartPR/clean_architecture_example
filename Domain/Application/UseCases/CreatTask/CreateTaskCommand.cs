using Domain.Core.ValueObjects.Enums;

namespace Domain.Application.UseCases.CreatTask;

public class CreateTaskCommand(Guid userId, string title, string description, DateTime dueDate, EPriority? priority, ICollection<Guid> tagsId)
{
	public Guid UserId { get; set; } = userId;

	public string Title { get; set; } = title;

	public string Description { get; set; } = description;

	public DateTime DueDate { get; set; } = dueDate;

	public EPriority? Priority { get; set; } = priority;

	public ICollection<Guid> TagsId { get; set; } = tagsId;
}
