using DDD.Shared.Abstract.Exceptions;

namespace DDD.Domain.Exceptions;

internal class EmptyNameMedicineException : BaseMedicineException
{
    public EmptyNameMedicineException() : base("Name of medicine can not be empty.")
    {
        
    }
}

internal class EmptyNumberMedicineException : BaseMedicineException
{
    public EmptyNumberMedicineException() : base("Number of medicine can not be empty.")
    {

    }
}
