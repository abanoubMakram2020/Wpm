namespace wpm.Clinic.Domain.ValueObjects
{
    public record PatientId
    {
        public Guid Value { get; init; } = Guid.Empty;
        public static PatientId Create(Guid value)
        {
            return new PatientId(value);
        }
        public PatientId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentNullException("value", "PatientId is not valid.");
            Value = value;
        }
        public static implicit operator PatientId(Guid value) => new PatientId(value);
        public static implicit operator Guid(PatientId patientId) => patientId.Value;
    }
}
