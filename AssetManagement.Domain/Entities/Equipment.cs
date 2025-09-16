using AssetManagement.Domain.ValueObjects;

namespace AssetManagement.Domain.Entities
{
    public class Equipment
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public SerialNumber SerialNumber { get; private set; }
        public string Model { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public string Status { get; private set; }

        protected Equipment() { } // Para o EF Core

        public Equipment(string name, SerialNumber serialNumber, string model, DateTime purchaseDate)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            SerialNumber = serialNumber ?? throw new ArgumentNullException(nameof(serialNumber));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            PurchaseDate = purchaseDate;
            Status = "Active";
        }

        public void Update(string name, string model, string status)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }

        public void Deactivate()
        {
            Status = "Inactive";
        }

        public void Activate()
        {
            Status = "Active";
        }

        public bool IsActive => Status == "Active";
    }
}
