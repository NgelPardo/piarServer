using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Application.Abstractions.Email;
using PiarServer.Domain.Abstractions;
using PiarServer.Domain.Ajustes;
using PiarServer.Domain.AjustesPiar;
using PiarServer.Domain.Barreras;
using PiarServer.Domain.BarrerasPiar;
using PiarServer.Domain.Evaluaciones;
using PiarServer.Domain.EvaluacionesPiar;
using PiarServer.Domain.FirmasPiar;
using PiarServer.Domain.Materias;
using PiarServer.Domain.MateriasPiar;
using PiarServer.Domain.Objetivos;
using PiarServer.Domain.ObjetivosPiar;
using PiarServer.Domain.Piars;
using PiarServer.Domain.Users;
using PiarServer.Infrastructure.Data;
using PiarServer.Infrastructure.Email;
using PiarServer.Infrastructure.Outbox;
using PiarServer.Infrastructure.Repositories;
using Quartz;

namespace PiarServer.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<OutboxOptions>(configuration.GetSection("Outbox"));
        services.AddQuartz();
        services.AddQuartzHostedService( options => 
            options.WaitForJobsToComplete = true
        );
        services.ConfigureOptions<ProcessOutboxMessageSetup>();

        services.AddTransient<IEmailService, EmailService>();

        var connectionString = configuration.GetConnectionString("ConnectionString") 
            ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IAjustePiarRepository, AjustePiarRepository>();
        services.AddScoped<IAjusteRepository, AjusteRepository>();
        services.AddScoped<IBarreraPiarRepository, BarreraPiarRepository>();
        services.AddScoped<IBarreraRepository, BarreraRepository>();
        services.AddScoped<IEvaluacionPiarRepository, EvaluacionPiarRepository>();
        services.AddScoped<IEvaluacionRepository, EvaluacionRepository>();
        services.AddScoped<IFirmaPiarRepository, FirmaPiarRepository>();
        services.AddScoped<IMateriaPiarRepository, MateriaPiarRepository>();
        services.AddScoped<IMateriaRepository, MateriaRepository>();
        services.AddScoped<IObjetivoPiarRepository, ObjetivoPiarRepository>();
        services.AddScoped<IObjetivoRepository, ObjetivoRepository>();
        services.AddScoped<IPiarRepository, PiarRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>( _ => {
            return new SqlConnectionFactory(connectionString);
        });

        return services;
    }
}