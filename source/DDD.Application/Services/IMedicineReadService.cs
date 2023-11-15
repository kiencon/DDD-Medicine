namespace DDD.Application.Services;

public interface IMedicineReadService
{
    Task<bool> IsExistedMedicice(string name, string number);
}
