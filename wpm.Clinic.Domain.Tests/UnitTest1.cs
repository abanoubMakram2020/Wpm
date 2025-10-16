using wpm.Clinic.Domain.Entities;
using wpm.Clinic.Domain.ValueObjects;

namespace wpm.Clinic.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void consultation_should_be_open()
        {
            var c = new Consultation(Guid.NewGuid());
            Assert.Equal(ConsultationStatus.Open, c.Status);
        }




        [Fact]
        public void consultation_should_not_ended_when_missing_data()
        {
            var c = new Consultation(Guid.NewGuid());
            Assert.Throws<InvalidOperationException>(c.End);
        }

        [Fact]
        public void consultation_should_end_with_complete_data()
        {
            var c = new Consultation(Guid.NewGuid());
            c.SetDiagnosis("diagnosis");
            c.SetTreatment("treatment");
            c.SetWeight(10);
            c.End();
            Assert.True(c.Status == ConsultationStatus.Closed);
        }

        [Fact]
        public void consultation_should_not_allow_weight_updates_when_closed()
        {
            var c = new Consultation(Guid.NewGuid());
            c.SetDiagnosis("diagnosis");
            c.SetTreatment("treatment");
            c.SetWeight(10);
            c.End();
            Assert.Throws<InvalidOperationException>(() => c.SetWeight(20));
        }

        [Fact]
        public void consultation_should_not_allow_diagnosis_updates_when_closed()
        {
            var c = new Consultation(Guid.NewGuid());
            c.SetDiagnosis("diagnosis");
            c.SetTreatment("treatment");
            c.SetWeight(10);
            c.End();
            Assert.Throws<InvalidOperationException>(() => c.SetDiagnosis("diagnosis"));
        }

        [Fact]
        public void consultation_should_not_allow_treatment_updates_when_closed()
        {
            var c = new Consultation(Guid.NewGuid());
            c.SetDiagnosis("diagnosis");
            c.SetTreatment("treatment");
            c.SetWeight(10);
            c.End();
            Assert.Throws<InvalidOperationException>(() => c.SetTreatment("treatment"));
        }

        [Fact]
        public void consultation_should_administer_drug()
        {
            var drugId = new DrugId(Guid.NewGuid());
            var c = new Consultation(Guid.NewGuid());
            c.AdministerDrug(drugId, new Dose(20, UnitOfMeasure.mg));
            Assert.True(c.AdministeredDrugs.Count == 1);
            Assert.True(c.AdministeredDrugs[0].DrugId == drugId);
        }

        [Fact]
        public void consultation_should_register_vitalsigns()
        {
            var c = new Consultation(Guid.NewGuid());
            IEnumerable<VitalSigns> vitalSigns = new List<VitalSigns>()
            {
                new VitalSigns(DateTime.Now,120,80, 20),
                new VitalSigns(DateTime.Now,130,85, 22)
            };
            c.RegisterVitalSigns(vitalSigns);
            Assert.True(c.VitalSignReadings.Count == 2);
            Assert.True(c.VitalSignReadings[0] == vitalSigns.First());
        }
    }
}