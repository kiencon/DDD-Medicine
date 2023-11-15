using DDD.Shared.Abstract.Exceptions;

namespace DDD.Application.Exceptions;

public class NotFoundRawMaterialException : BaseMedicineException
{
    public NotFoundRawMaterialException() : base("Any raw material has not found.")
    {
        
    }
}

public class ExistedRawMaterialException : BaseMedicineException
{
    public string Name { get; set; }

    public ExistedRawMaterialException(string name) : base($"Raw material with name: {name} existed already.")
    {
        Name = name;
    }
}
