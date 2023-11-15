using DDD.Application.Exceptions;
using DDD.Application.Services;
using DDD.Domain.Factories.Interfaces;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects.RawMaterial;
using DDD.Shared.Abstract.Command;

namespace DDD.Application.RawMaterial.Commands;

internal class CreateRawMaterialHandler : ICommandHandler<CreateRawMaterial, Guid>
{
    private readonly IRawMaterialRepository _rawMaterialRepository;
    private readonly IRawMaterialFactory _rawMaterialFactory;
    private readonly IRawMaterialReadService _rawMaterialReadService;
    public CreateRawMaterialHandler(
        IRawMaterialRepository rawMaterialRepository, 
        IRawMaterialFactory rawMaterialFactory,
        IRawMaterialReadService rawMaterialReadService)
    {
        _rawMaterialRepository = rawMaterialRepository;
        _rawMaterialFactory = rawMaterialFactory;
        _rawMaterialReadService = rawMaterialReadService;
    }

    public async Task<Guid> Handle(CreateRawMaterial request, CancellationToken cancellationToken)
    {
        var (name, rawMaterialStatus) = request;

        if (await _rawMaterialReadService.IsExistedRawMaterial(name))
        {
            throw new ExistedRawMaterialException(name);
        }

        var rawMaterial = _rawMaterialFactory.CreateUnique(RawMaterialDataVO.Create(name, rawMaterialStatus));
        await _rawMaterialRepository.AddAsync(rawMaterial);

        return rawMaterial.Id;
    }
}
