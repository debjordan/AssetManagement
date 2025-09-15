namespace AssetManagement.Domain.Exceptions
{
    public class EquipmentNotFoundException : Exception
    {
        public EquipmentNotFoundException(Guid id)
            : base($"Equipment with ID {id} was not found.")
        {
        }
    }
}
