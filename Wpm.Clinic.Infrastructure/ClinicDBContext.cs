using Microsoft.EntityFrameworkCore;
using wpm.Clinic.Domain.Entities;
using wpm.Clinic.Domain.ValueObjects;

namespace Wpm.Clinic.Infrastructure
{
    public class ClinicDBContext(DbContextOptions option) : DbContext(option)
    {
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<DrugAdministration> DrugAdministrations { get; set; }
        public DbSet<VitalSigns> VitalSigns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDBContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Consultation>().HasKey(p => p.Id);
            modelBuilder.Entity<Consultation>().OwnsOne(p => p.Diagnosis);
            modelBuilder.Entity<Consultation>().OwnsOne(p => p.Treatment);
            modelBuilder.Entity<Consultation>().OwnsOne(p => p.CurrentWeight);
            modelBuilder.Entity<Consultation>().OwnsOne(p => p.When);
            modelBuilder.Entity<Consultation>().Property(p => p.PatientId).HasConversion(v => v.Value, v => PatientId.Create(v));

            modelBuilder.Entity<Consultation>().OwnsMany(c => c.AdministeredDrugs, a =>
            {
                a.WithOwner().HasForeignKey("ConsultationId");
                a.OwnsOne(d => d.DrugId);
                a.OwnsOne(d => d.Dose);
            });

            modelBuilder.Entity<Consultation>().OwnsMany(c => c.VitalSignReadings, v =>
            {
                v.WithOwner().HasForeignKey("ConsultationId");
            });

        }
    }
}