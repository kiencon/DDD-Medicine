using DDD.Domain.Const;
using DDD.Shared.Abstract.Command;

namespace DDD.Application.RawMaterial.Commands;

public record CreateRawMaterial(
    string Name, 
    RawMaterialStatus RawMaterialStatus = RawMaterialStatus.Inactive) : ICommand<Guid>;
