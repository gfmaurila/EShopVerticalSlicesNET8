using API.Basket.Domain.User.Events;
using API.Basket.Feature.Users.GetUser;
using API.Basket.Infrastructure.Database.Repositories.Interfaces;
using MediatR;
using poc.core.api.net8.Interface;

namespace API.Basket.Feature.Users.UpdateUser.Events;

public class UserUpdatedEventHandler : INotificationHandler<UserUpdatedEvent>
{
    private readonly ILogger<UserUpdatedEventHandler> _logger;
    private readonly IUserRepository _repo;
    private readonly IRedisCacheService<List<UserQueryModel>> _cacheService;
    public UserUpdatedEventHandler(ILogger<UserUpdatedEventHandler> logger,
                                   IUserRepository repo,
                                   IRedisCacheService<List<UserQueryModel>> cacheService)
    {
        _logger = logger;
        _repo = repo;
        _cacheService = cacheService;
    }

    public async Task Handle(UserUpdatedEvent notification, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetUserQuery);
        await _cacheService.DeleteAsync(cacheKey);
        await _cacheService.GetOrCreateAsync(cacheKey, _repo.GetAllAsync, TimeSpan.FromHours(2));
    }
}
