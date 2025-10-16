using wpm.Clinic.Domain.ValueObjects;
using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernal;
using Wpm.SharedKernal.ValueObjects;

namespace wpm.Clinic.Domain.Entities
{
    public class Consultation : AggregateRoot
    {
        private readonly List<DrugAdministration> administeredDrugs = new();
        private readonly List<VitalSigns> vitalSignReadings = new();
        public DateTimeRange When { get; private set; }
        public PatientId PatientId { get; init; }
        public Text? Diagnosis { get; private set; }
        public Text? Treatment { get; private set; }
        public Weight? CurrentWeight { get; private set; }
        public ConsultationStatus Status { get; private set; }
        public IReadOnlyList<DrugAdministration> AdministeredDrugs => administeredDrugs.AsReadOnly();
        public IReadOnlyList<VitalSigns> VitalSignReadings => vitalSignReadings.AsReadOnly();

        public Consultation(PatientId patientId)
        {
            Id = Guid.NewGuid();
            PatientId = patientId;
            Status = ConsultationStatus.Open;
            When = DateTime.UtcNow;
        }

        public void RegisterVitalSigns(IEnumerable<VitalSigns> vitalSigns)
        {
            ValidateConsultationStatus();
            vitalSignReadings.AddRange(vitalSigns);
        }
        public void AdministerDrug(DrugId drugId, Dose dose)
        {
            ValidateConsultationStatus();
            var newDrugAdministration = new DrugAdministration(drugId, dose);
            administeredDrugs.Add(newDrugAdministration);
        }
        public void SetWeight(Weight weight)
        {
            ValidateConsultationStatus();
            CurrentWeight = weight;
        }

        public void SetDiagnosis(Text diagnosis)
        {
            ValidateConsultationStatus();
            Diagnosis = diagnosis;
        }
        public void SetTreatment(Text treatment)
        {
            ValidateConsultationStatus();
            Treatment = treatment;
        }
        private void ValidateConsultationStatus()
        {
            if (Status == ConsultationStatus.Closed)
            {
                throw new InvalidOperationException("the consulation already closed");
            }
        }
        public void End()
        {
            ValidateConsultationStatus();
            if (Diagnosis is null || Treatment is null || CurrentWeight is null)
            {
                throw new InvalidOperationException("the consulation cannot be Ended");

            }
            Status = ConsultationStatus.Closed;
            When = new DateTimeRange(When.StartedAt, DateTime.UtcNow);
        }
    }

    public enum ConsultationStatus
    {
        Open,
        Closed
    }
}
