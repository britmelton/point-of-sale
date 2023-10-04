namespace Domain;

public abstract class Entity
{
    protected Entity(Guid? id = default)
    {
        Id = id is null || id == Guid.Empty ? Guid.NewGuid() : id.Value;
    }

    public Guid Id { get; }
}