namespace DDD.Infrastructure.EF.Entities;

internal abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set;}
}

/*
 * 

PM> Scaffold-DbContext "Server=localhost;Database=Audit;Username=postgres;Password=postgres;" Npgsql.EntityFrameworkCore.PostgreSqlServer -OutputDir Models


 * 
 */