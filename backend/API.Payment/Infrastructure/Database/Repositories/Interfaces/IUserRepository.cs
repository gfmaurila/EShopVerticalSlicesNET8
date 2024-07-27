using API.Payment.Domain.User;
using API.Payment.Feature.Users.GetUser;
using poc.core.api.net8.Abstractions;
using poc.core.api.net8.ValueObjects;

namespace API.Payment.Infrastructure.Database.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<bool> ExistsByEmailAsync(Email email);
    Task<bool> ExistsByEmailAsync(Email email, Guid currentId);
    Task<List<UserQueryModel>> GetAllAsync();
    Task<UserQueryModel> GetByIdAsync(Guid id);
    Task<UserEntity> GetAuthByEmailPassword(string email, string passwordHash);
    Task<UserEntity> GetByEmailAsync(string email);
}

