using DDD.Shared.Abstract.Exceptions;

namespace DDD.Domain.Exceptions;

public class EmptyFormulaIdException : BaseMedicineException
{
    public EmptyFormulaIdException() : base("Formula Id is empty.")
    {
        
    }
}

public class FormulaRatioInvalidException: BaseMedicineException
{
    public FormulaRatioInvalidException() : base("The total of ratio in fomula must be 1.")
    {
        
    }
}
