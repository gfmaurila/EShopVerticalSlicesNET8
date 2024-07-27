using API.Payment.Domain.User.Events;
using API.Payment.Feature.Users.GetUser;
using API.Payment.Infrastructure.Database.Repositories.Interfaces;
using MediatR;
using poc.core.api.net8.Interface;

namespace API.Payment.Feature.Users.DeleteUser.Events;

public class UserDeletedEventHandler : INotificationHandler<UserDeletedEvent>
{
    private readonly ILogger<UserDeletedEventHandler> _logger;
    private readonly IUserRepository _repo;
    private readonly IRedisCacheService<List<UserQueryModel>> _cacheService;
    public UserDeletedEventHandler(ILogger<UserDeletedEventHandler> logger,
                                   IUserRepository repo,
                                   IRedisCacheService<List<UserQueryModel>> cacheService)
    {
        _logger = logger;
        _repo = repo;
        _cacheService = cacheService;
    }

    public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetUserQuery);
        await _cacheService.DeleteAsync(cacheKey);
        await _cacheService.GetOrCreateAsync(cacheKey, _repo.GetAllAsync, TimeSpan.FromHours(2));
    }
}
