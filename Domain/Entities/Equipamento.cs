public class Equipamento
{
    public Guid Id { get; set; }
    public string Codigo { get; set; }
    public string Hostname { get; set; }
    public string N_Serie { get; set; }
    public string Fabrica { get; set; }
    public string Setor { get; set; }
    public DateTime CreatedAt { get; set; } // Data de criação
    public DateTime UpdatedAt { get; set; } // Data que foi atualizada

    public Equipamento(string codigo, string hostname, string n_Serie, string fabrica, string setor)
    {
        Id = Guid.NewGuid();
        Codigo = codigo;
        Hostname = hostname;
        N_Serie = n_Serie;
        Fabrica = fabrica;
        Setor = setor;
        CreatedAt = DateTime.UtcNow; // Define a data de criação    
        UpdatedAt = DateTime.UtcNow; // Define a data de atualização
    }
}
