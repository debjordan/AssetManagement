namespace AssetManagement.Domain.Entities
{
    public class Equipment
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public Equipment(string name, string code, string description)
        {
            Name = name;
            Code = code;
            Description = description;
        }

        public void Update(string name, string code, string description)
        {
            Name = name;
            Code = code;
            Description = description;
        }
    }
}
