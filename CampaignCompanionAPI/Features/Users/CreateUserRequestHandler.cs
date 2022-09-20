using System;
using CampaignCompanionAPI.Data.Entities;
using CampaignCompanionAPI.Data.Repositories;

namespace CampaignCompanionAPI.Features.Users
{
    public class CreateUserRequest : IRequest
    {
        public string DiscordId { get; set; }
    }
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, User>
    {
        private readonly IRepository<User> _userRepository;
        public CreateUserRequestHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> HandleRequest(CreateUserRequest request)
        {
            var users = await _userRepository.GetAll();
            var user = users.SingleOrDefault(x => x.DiscordId == request.DiscordId);
            if (user != null)
                return user;

            return await _userRepository.Add(new User(request.DiscordId));
        }
    }
}

