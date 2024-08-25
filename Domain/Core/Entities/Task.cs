using Domain.Core.ValueObjects.Enums;

namespace Domain.Core.Entities;

internal class Task
{
	public Guid Id { get; private set; }
	public string Title { get; private set; }
	public string Description { get; private set; }
	public bool IsCompleted { get; private set; }
	public DateTime DueDate { get; private set; }
	public DateTime CreatedDate { get; private set; }
	public EPriority? Priority { get; private set; }
	public ICollection<Tag> Tags { get; private set; }

	public Task(string title, string description, DateTime dueDate, EPriority? priority = null, ICollection<Tag>? tags = null, Guid? id = null)
	{
		Id = id ?? Guid.NewGuid();
		Title = title;
		Description = description;
		IsCompleted = false;
		DueDate = dueDate;
		CreatedDate = DateTime.UtcNow;
		Priority = priority;
		Tags = tags ?? new HashSet<Tag>();

		Validate();
	}

	private void Validate()
	{
		if (string.IsNullOrEmpty(Title))
			throw new ArgumentNullException(nameof(Title));

		if (string.IsNullOrEmpty(Description))
			throw new ArgumentNullException(nameof(Description));
	}

	public void AlterTitle(string title)
	{
		Title = title;
		Validate();
	}

	public void AlterDescription(string description) 
	{
		Description = description; 
		Validate(); 
	}

	public void AlterDueDate(DateTime dueDate)
	{
		DueDate = dueDate;
		Validate();
	}

	public void AlterPriority(EPriority priority)
	{
		Priority = priority;
	}

	public void AddTag(Tag tag)
	{
		Tags.Add(tag);
	}

	public void removeTag(Tag tag)
	{
		Tags.Remove(tag);
	}

	public void Complete()
	{
		IsCompleted = true;
	}
}
