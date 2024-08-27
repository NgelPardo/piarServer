using Bogus;
using Dapper;
using PiarServer.Application.Abstractions.Data;
using PiarServer.Domain.Users;
using PiarServer.Infrastructure;

namespace PiarServer.Api.Extensions;

public static class SeedDataExtensions
{

    public static void SeedDataAuthentication(
        this IApplicationBuilder app
    )
    {
        using var scope = app.ApplicationServices.CreateScope();
        var service = scope.ServiceProvider;
        var loggerFactory = service.GetRequiredService<ILoggerFactory>();

        try
        {
            var context = service.GetRequiredService<ApplicationDbContext>();

            if (!context.Set<User>().Any())
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword("SuperAdmin123$");

                var user = User.Create(
                    new Nombre("Miguel"),
                    new Apellido("Pardo"),
                    new Email("superadmin.piar@gmail.com"),
                    new PasswordHash(passwordHash),
                    DateTime.UtcNow,
                    null
                );

                context.Add(user);

                passwordHash = BCrypt.Net.BCrypt.HashPassword("Admin123$");

                user = User.Create(
                    new Nombre("Miguel"),
                    new Apellido("Pardo"),
                    new Email("admin.piar@gmail.com"),
                    new PasswordHash(passwordHash),
                    DateTime.UtcNow,
                    null
                );

                context.Add(user);

                passwordHash = BCrypt.Net.BCrypt.HashPassword("Profesor123$");

                user = User.Create(
                    new Nombre("Miguel"),
                    new Apellido("Pardo"),
                    new Email("profesor.piar@gmail.com"),
                    new PasswordHash(passwordHash),
                    DateTime.UtcNow,
                    null
                );

                context.Add(user);

                passwordHash = BCrypt.Net.BCrypt.HashPassword("Auxiliar123$");

                user = User.Create(
                    new Nombre("Miguel"),
                    new Apellido("Pardo"),
                    new Email("auxiliar.piar@gmail.com"),
                    new PasswordHash(passwordHash),
                    DateTime.UtcNow,
                    passwordNoHash: null
                );

                context.Add(user);

                context.SaveChangesAsync().Wait();
            }
                
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApplicationDbContext>();
            logger.LogError(ex.Message);
        }
    }
    // public static void SeedData(this IApplicationBuilder app)
    // {
    //     using var scope = app.ApplicationServices.CreateScope();
    //     var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
    //     using var connection = sqlConnectionFactory.CreateConnection();

    //     var faker = new Faker();

    //     List<object> materias = new();

    //     for (int i = 0; i < 5; i++)
    //     {
    //         materias.Add(new
    //         {
    //             Id = Guid.NewGuid(),
    //             IdUss = Guid.NewGuid(),
    //             IdProf = Guid.NewGuid(),
    //             NomMat = faker.Vehicle.Model(),
    //             FecDil = DateTime.MinValue
    //         });
    //     }

    //     const string sql = """
    //         INSERT INTO public.materias
    //             (id,id_uss,id_prof,nom_mat,fec_dil)
    //             values(@Id,@IdUss,@IdProf,@NomMat,@FecDil)
    //     """;

    //     connection.Execute(sql, materias);
    // }
}