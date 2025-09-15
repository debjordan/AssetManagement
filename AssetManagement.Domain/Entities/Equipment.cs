using AssetManagement.Domain.ValueObjects;

namespace AssetManagement.Domain.Entities
{
    public class Equipment
    {
        public string Name { get; private set; }
        public SerialNumber SerialNumber { get; private set; }
        public string Model { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public string Status { get; private set; }

        protected Equipment() { }

        public Equipment(string name, SerialNumber serialNumber, string model, DateTime purchaseDate)
        {
            Name = name;
            SerialNumber = serialNumber;
            Model = model;
            PurchaseDate = purchaseDate;
            Status = "Active";
        }

        public void Update(string name, string model, string status)
        {
            Name = name;
            Model = model;
            Status = status;
        }

        public void Deactivate()
        {
            Status = "Inactive";
        }
    }
}
