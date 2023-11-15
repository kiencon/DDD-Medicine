using DDD.Shared.Abstract.Exceptions;

namespace DDD.Domain.Exceptions;

public class EmptyRawMaterialIdException : BaseMedicineException
{
    public EmptyRawMaterialIdException() : base("Raw material id is empty.")
    {

    }
}

public class EmptyNameRawMaterialExpcetion : BaseMedicineException
{
    public EmptyNameRawMaterialExpcetion() : base("Name of raw material cannot be empty.")
    {
        
    }
}

public class RawMaterialRatioInvalidException : BaseMedicineException
{
    public RawMaterialRatioInvalidException() : base("Value of raw material ratio is invalid.")
    {
        
    }
}

public class RawMaterialRatioNotFoundException : BaseMedicineException
{
    public string Name { get; set; }
    public RawMaterialRatioNotFoundException(string name) 
        : base($"Raw material ratio with name {name} not found.")
    {
        Name = name;
    }
}