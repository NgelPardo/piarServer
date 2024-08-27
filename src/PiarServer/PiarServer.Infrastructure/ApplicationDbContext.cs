using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PiarServer.Application.Exceptions;
using PiarServer.Domain.Abstractions;
using PiarServer.Infrastructure.Outbox;

namespace PiarServer.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{

    private static readonly JsonSerializerSettings jsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All
    };
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default
    )
    {
        try
        {

            //await PublishDomainEventsAsync();
            AddDomainEventsToOutboxMessage();
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
        catch ( DbUpdateConcurrencyException ex )
        {
            throw new ConcurrencyException("La excepcion por concurrencia se disparo", ex);
        }
    }

    private void AddDomainEventsToOutboxMessage()
    {
        var outboxMessages = ChangeTracker
            .Entries<IEntity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();
                entity.ClearDomainEvents();
                return domainEvents;
            })
            .Select(domainEvent => new OutboxMessage(
                Guid.NewGuid(),
                DateTime.UtcNow,
                domainEvent.GetType().Name,
                JsonConvert.SerializeObject(domainEvent, jsonSerializerSettings)
            )).ToList();

        AddRange(outboxMessages);

    }
    
}