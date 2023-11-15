namespace DDD.Application.Services;

public interface IRawMaterialReadService
{
    Task<bool> IsNotFoundRawMaterial(IEnumerable<Guid> rawMaterialIds);
    Task<Dictionary<Guid, string>> GetRawMaterialNameMap(IEnumerable<Guid> rawMaterialIds);
    Task<bool> IsExistedRawMaterial(string name);
}
