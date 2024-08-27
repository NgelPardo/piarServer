namespace PiarServer.Domain.Abstractions;

public abstract class EntityInt
{
    protected EntityInt()
    {
    }

    private readonly List<IDomainEvent> _domainEvents = new();

    protected EntityInt(int id)
    {
        Id = id;
    }

    public int Id { get; init; }

}
