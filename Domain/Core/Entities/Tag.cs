namespace Domain.Core.Entities;

internal class Tag
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string Color { get; private set; }

    public Tag(string name, string color, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Color = color;

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(Name))
            throw new ArgumentException(nameof(Name));

        // Color poderia ser um ObjectValue e ter sua própria validação
        if (string.IsNullOrEmpty(Color))
            throw new ArgumentException(nameof(Color));
    }

    public void AlterName(string name)
    {
        Name = name;
        Validate();
    }

    public void AlterColor(string color)
    {
        Color = color;
        Validate();
    }
}
