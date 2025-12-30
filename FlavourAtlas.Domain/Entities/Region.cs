namespace FlavourAtlas.Domain.Entities;

public class Region
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;

    private Region() { } // EF Core

    public Region(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
