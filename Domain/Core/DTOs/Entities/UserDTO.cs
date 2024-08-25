using Domain.Application.DTOs.Entities;
using Domain.Application.DTOs.ValueObjects;

namespace Domain.Core.DTOs.Entities;

public class UserDTO(Guid id, string name, EmailDTO email, ICollection<TaskDTO> tasks)
{
	public Guid Id { get; set; } = id;
	public string Name { get; set; } = name;
	public EmailDTO Email { get; set; } = email;
	public ICollection<TaskDTO> Tasks { get; set; } = tasks;
}
