using AssetManagement.Domain.Entities;

public class Defeito
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public Guid CategoriaId { get; set; }
    public CategoriaDefeito Categoria { get; set; }
    public DateTime DataRegistro { get; set; }
    public DateTime? DataResolucao { get; set; }

    public Defeito() { }

    public Defeito(string descricao, CategoriaDefeito categoria)
    {
        Descricao = descricao;
        Categoria = categoria;
        DataRegistro = DateTime.Now;
    }
}
