using Domain.Core.ValueObjects.Enums;

namespace Domain.Application.DTOs.Entities;

public class TaskDTO(Guid id, string title, string description, bool isCompleted, DateTime dueDate, DateTime createdDate, EPriority? priority, ICollection<TagDTO> tags)
{
	public Guid Id { get; set; } = id;
	public string Title { get; set; } = title;
	public string Description { get; set; } = description;
	public bool IsCompleted { get; set; } = isCompleted;
	public DateTime DueDate { get; set; } = dueDate;
	public DateTime CreatedDate { get; set; } = createdDate;
	public EPriority? Priority { get; set; } = priority;
	public ICollection<TagDTO> Tags { get; set; } = tags;
}
