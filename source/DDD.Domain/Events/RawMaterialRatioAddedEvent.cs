using DDD.Domain.Aggregate;
using DDD.Domain.ValueObjects.Formula;
using DDD.Shared.Abstract.Domain;

namespace DDD.Domain.Events;

public record RawMaterialRatioAddedEvent(Formula Formula, RawMaterialRatioVO RawMaterialRatioVO) : IDomainEvent;
