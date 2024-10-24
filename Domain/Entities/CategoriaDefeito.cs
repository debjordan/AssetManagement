namespace AssetManagement.Domain.Entities;
public class CategoriaDefeito
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public CategoriaDefeito(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}
