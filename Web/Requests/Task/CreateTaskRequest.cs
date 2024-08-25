using Domain.Core.ValueObjects.Enums;

namespace Web.Requests.Task;

public class CreateTaskRequest
{
	public string Title { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public DateTime DueDate { get; set; }

	public EPriority? Priority { get; set; }

	public ICollection<Guid> TagsId { get; set; } = new HashSet<Guid>();
}
