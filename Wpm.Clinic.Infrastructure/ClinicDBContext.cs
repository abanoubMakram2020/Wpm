using Microsoft.EntityFrameworkCore;
using wpm.Clinic.Domain.Entities;
using wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernal;

namespace Wpm.Clinic.Infrastructure
{
    public class ClinicDBContext(DbContextOptions option) : DbContext(option)
    {
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<DrugAdministration> DrugAdministrations { get; set; }
        public DbSet<VitalSigns> VitalSigns { get; set; }
        //public DbSet<ConsultationEventData> EventsData { get; set; }

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
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            var domainEntities = ChangeTracker.Entries<AggregateRoot>()
                .Where(x => x.Entity.GetChanges.Any())
                .Select(x => x.Entity)
                .ToList();

            var events = domainEntities.SelectMany(x => x.GetChanges).ToList();
            domainEntities.ForEach(e => e.ClearChanges());

            foreach (var domainEvent in events)
                // base.Update(new ConsultationEventData(
                Console.WriteLine($"{Guid.NewGuid()},{(domainEvent as dynamic).Id},{domainEvent.GetType().Name},{System.Text.Json.JsonSerializer.Serialize(domainEvent, domainEvent.GetType())},{domainEvent.GetType().AssemblyQualifiedName}");
            //));

            return result;
        }
        // public record ConsultationEventData(Guid Id, Guid AggregateId, string EventName, string Data, string AssemblyQualifiedName);
    }
}