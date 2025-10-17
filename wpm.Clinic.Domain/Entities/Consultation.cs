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
        public PatientId PatientId { get; private set; }
        public Text? Diagnosis { get; private set; }
        public Text? Treatment { get; private set; }
        public Weight? CurrentWeight { get; private set; }
        public ConsultationStatus Status { get; private set; }
        public IReadOnlyList<DrugAdministration> AdministeredDrugs => administeredDrugs.AsReadOnly();
        public IReadOnlyList<VitalSigns> VitalSignReadings => vitalSignReadings.AsReadOnly();

        public Consultation(PatientId patientId) => ApplyDomainEvent(new Events.ConsultationStarted(Guid.NewGuid(), patientId, DateTime.UtcNow));

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
        public void SetWeight(Weight weight) => ApplyDomainEvent(new Events.WeightUpdated(Id, weight));

        public void SetDiagnosis(Text diagnosis) => ApplyDomainEvent(new Events.DiagnosisUpdated(Id, diagnosis));

        public void SetTreatment(Text treatment) => ApplyDomainEvent(new Events.TreatmentUpdated(Id, treatment));

        private void ValidateConsultationStatus()
        {
            if (Status == ConsultationStatus.Closed)
            {
                throw new InvalidOperationException("the consulation already closed");
            }
        }
        public void End() => ApplyDomainEvent(new Events.ConsultationEnded(Id, DateTime.UtcNow));

        protected override void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent)
        {
            switch (domainEvent)
            {
                case Events.ConsultationStarted e:
                    Id = e.Id;
                    PatientId = e.PatientId;
                    When = e.StartedAt;
                    Status = ConsultationStatus.Open;
                    break;
                case Events.DiagnosisUpdated e:
                    ValidateConsultationStatus();
                    Diagnosis = e.diagnosis;
                    break;
                case Events.TreatmentUpdated e:
                    ValidateConsultationStatus();
                    Treatment = e.treatment;
                    break;
                case Events.WeightUpdated e:
                    ValidateConsultationStatus();
                    CurrentWeight = e.Weight;
                    break;
                case Events.ConsultationEnded e:
                    ValidateConsultationStatus();
                    if (Diagnosis is null || Treatment is null || CurrentWeight is null)
                    {
                        throw new InvalidOperationException("the consulation cannot be Ended");

                    }
                    Status = ConsultationStatus.Closed;
                    When = new DateTimeRange(When.StartedAt, DateTime.UtcNow);
                    break;

            }
        }
    }

    public enum ConsultationStatus
    {
        Open,
        Closed
    }
}
