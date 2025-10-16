using Wpm.SharedKernal;

namespace wpm.Clinic.Domain.ValueObjects
{
    public class VitalSigns : Entity
    {
        public DateTime ReadingDateTime { get; init; }
        public decimal Temperature { get; init; } // in Celsius
        public int HeartRate { get; init; } // in beats per minute
        public int RespirationRate { get; init; }
        public VitalSigns(DateTime readingDateTime, decimal temperature, int heartReate, int respirationRate)
        {
            Id = Guid.NewGuid();
            ReadingDateTime = readingDateTime;
            Temperature = temperature;
            HeartRate = heartReate;
            RespirationRate = respirationRate;
        }
        public VitalSigns()
        {

        }
    }
}
