using DDD.Shared.Abstract.Exceptions;

namespace DDD.Application.Exceptions;

public class ExistedMedicineException : BaseMedicineException
{
    public string Name { get; set; }
    public string Number { get; set; }
    public ExistedMedicineException(string name, string number)
        : base($"Medicine with name: {name} and number: {number} is existed")
    {
        Name = name;
        Number = number;    
    }
}
