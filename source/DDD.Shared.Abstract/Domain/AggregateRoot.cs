namespace DDD.Shared.Abstract.Domain;

public abstract class AggregateRoot<TId> where TId : notnull
{
    protected AggregateRoot() 
    {
        Id = default!;
    }

    protected AggregateRoot(TId id)
    {
        Id = id;
    }

    public TId Id { get; protected set; }
    public int Version { get; protected set; }
    protected DateTime _updatedAt = DateTime.UtcNow;

    private readonly List<IDomainEvent> _events = new();
    private bool _versionIncremented;

    protected void AddEvent(IDomainEvent @event)
    {
        if (!_events.Any() && !_versionIncremented)
        {
            Version++;
            _versionIncremented = true;
        }

        _events.Add(@event);
    }

    public void ClearEvents() => _events.Clear();

    protected void IncrementVersion()
    {
        if (_versionIncremented)
        {
            return;
        }

        Version++;
        _versionIncremented = true;
    }
}
