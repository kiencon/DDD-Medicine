using DDD.Domain.Aggregate;
using DDD.Domain.ValueObjects.Formula;
using DDD.Shared.Abstract.Domain;

namespace DDD.Domain.Events;

public record RawMaterialRatioUpdatedEvent(
    Formula Formula, 
    RawMaterialRatioVO OldOne,
    RawMaterialRatioVO NewOne) : IDomainEvent;
