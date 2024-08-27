using Microsoft.EntityFrameworkCore;
using PiarServer.Domain.Users;

namespace PiarServer.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetByEmailAsync(Domain.Users.Email email, CancellationToken cancellationToken = default)
    {
        var users = await DbContext.Set<User>().ToListAsync(cancellationToken);

        return await DbContext.Set<User>()
        .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
    public async Task<UserRole?> GetByIdUserRoleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<UserRole>()
        .FirstOrDefaultAsync(x => x.idUss == id, cancellationToken);
    }

    public async Task<bool> IsUserExists(
        Domain.Users.Email email, 
        CancellationToken cancellationToken = default
        )
    {
        return await DbContext.Set<User>()
        .AnyAsync(x => x.Email == email);
    }

    public Task AddUserRoleAsync(UserRole userRole, CancellationToken cancellationToken = default)
    {
        DbContext.Set<UserRole>().Add(userRole);
        return Task.CompletedTask;
    }

    public Task UpdateUserRoleAsync(UserRole userRole, CancellationToken cancellationToken = default)
    {
        DbContext.Set<UserRole>().Update(userRole);
        return Task.CompletedTask;
    }

    public async Task Update(User user, CancellationToken cancellationToken = default)
    {
        DbContext.Set<User>().Update(user);
        await Task.CompletedTask;
    }

    public void RemoveRole(UserRole userRole)
    {
        DbContext.Remove(userRole);
    }
}