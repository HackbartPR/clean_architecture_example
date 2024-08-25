namespace Domain.Application.DTOs.Entities;

public class TagDTO(Guid id, string name, string color)
{
	public Guid Id { get; set; } = id;
	public string Name { get; set; } = name;
	public string Color { get; set; } = color;
}
