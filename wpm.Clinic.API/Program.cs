
using Microsoft.EntityFrameworkCore;
using wpm.Clinic.Domain.Repositories;
using Wpm.Clinic.ApplicationService.Handlers;
using Wpm.Clinic.Infrastructure;
using Wpm.Clinic.Infrastructure.Repositories;
using Wpm.SharedKernal.Command;
using Wpm.SharedKernal.ValueObjects;

namespace wpm.Clinic.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();
            builder.Services.AddScoped<ICommandHandler<EndConsultationCommand>, EndConsultationCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<SetDiagnosisCommand>, SetDiagnosisCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<SetTreatmentCommand>, SetTreatmentCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<SetWeightCommand>, SetWeightCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<AdministerDrugCommand>, AdministerDrugCommandHandler>();
            builder.Services.AddScoped<ICommandHandler<RegisterVitalSignsCommand>, RegisterVitalSignsCommandHandler>();
            builder.Services.AddScoped<StartConsultationCommandHandler>();
            builder.Services.AddDbContext<ClinicDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WpmClinicDb")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
