namespace wpm.Clinic.Domain.ValueObjects
{
    public record VitalSigns
    {
        public DateTime ReadingDateTime { get; init; }
        public decimal Temperature { get; init; } // in Celsius
        public int HeartRate { get; init; } // in beats per minute
        public int RespirationRate { get; init; }
        public VitalSigns(decimal temperature, int heartReate, int respirationRate)
        {
            ReadingDateTime = DateTime.Now;
            Temperature = temperature;
            HeartRate = heartReate;
            RespirationRate = respirationRate;
        }
    }
}
