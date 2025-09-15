namespace AssetManagement.Domain.ValueObjects
{
    public class SerialNumber
    {
        public string Value { get; }

        public SerialNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Serial number cannot be empty");

            if (value.Length < 5)
                throw new ArgumentException("Serial number must be at least 5 characters");

            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is SerialNumber other && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(SerialNumber left, SerialNumber right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SerialNumber left, SerialNumber right)
        {
            return !Equals(left, right);
        }
    }
}
