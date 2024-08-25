using Domain.Core.ValueObjects.Objects;

namespace Domain.Core.Entities;

internal class User
{
	public Guid Id { get; private set; }
	public string Name { get; private set; }
	public Email Email { get; private set; }
	public ICollection<Task> Tasks { get; private set; }

	public User(string name, Email email, Guid? id = null)
	{
		Id = id ?? Guid.NewGuid();
		Name = name;
		Email = email;
		Tasks = new HashSet<Task>();

		Validate();
	}

	private void Validate()
	{
		if (string.IsNullOrEmpty(Name))
			throw new ArgumentException(nameof(Name));
	}
	
	public void AlterEmail(Email email)
	{
		Email = email;
	}

	public void AlterName(string name) 
	{ 
		Name = name;
		Validate();
	}

	public void AddTask(Task task)
	{
		Tasks.Add(task);
	}

	public void RemoveTask(Task task)
	{
		Tasks.Remove(task);
	}
}
