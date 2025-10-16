
using Microsoft.EntityFrameworkCore;
using wpm.Management.Domain;
using wpm.Management.Domain.Repositories;
using Wpm.Management.ApplicationService;
using Wpm.Management.Infrastructure;
using Wpm.Management.Infrastructure.Repositories;
using Wpm.SharedKernal.Command;

namespace wpm.Management.Api
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
            builder.Services.AddScoped<IManagementRepository, ManagementRepository>();
            builder.Services.AddScoped<IBreadService, BreadService>();
            builder.Services.AddScoped<ManagementApplicationService>();
            builder.Services.AddScoped<ICommandHandler<SetWeightCommand>, SetWeightCommandHandler>();
            // Fix: Use builder.Configuration instead of Configuration
            builder.Services.AddDbContext<ManagementDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WpmDb")));

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
            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var services = scope.ServiceProvider;

                    var context = services.GetRequiredService<ManagementDBContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetService<ILogger>();
                    throw;
                }

            }
            app.Run();
        }
    }
}
