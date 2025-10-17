namespace wpm.Clinic.Domain.ValueObjects
{
    public record Text
    {
        public string Value { get; init; } = string.Empty;

        public Text(string value)
        {
            Validate(value);
            Value = value;
        }

        private void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("value", "Text is not valid.");

            if (value.Length > 500)
                throw new ArithmeticException("Text too large ");
        }
        public static implicit operator Text(string value) => new Text(value);
        public static implicit operator string(Text text) => text.Value;
    }
}
