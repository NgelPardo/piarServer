namespace PiarServer.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserRole?> GetByIdUserRoleAsync(Guid id, CancellationToken cancellationToken= default);
    void Add(User user);
    void Remove(User user);
    void RemoveRole(UserRole userRole);
    Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
    Task<bool> IsUserExists(
        Email email,
        CancellationToken cancellationToken = default
    );
    Task Update(User user, CancellationToken cancellationToken = default);
    Task AddUserRoleAsync(UserRole role, CancellationToken cancellationToken = default);
    Task UpdateUserRoleAsync(UserRole role, CancellationToken cancellationToken = default);
}