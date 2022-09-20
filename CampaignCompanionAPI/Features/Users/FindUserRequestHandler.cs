using System;
using CampaignCompanionAPI.Data.Entities;
using CampaignCompanionAPI.Data.Repositories;

namespace CampaignCompanionAPI.Features.Users
{
    public class FindUserRequest: IRequest
    {
        public string DiscordId { get; set; }
    }
    public class FindUserRequestHandler : IRequestHandler<FindUserRequest, User?>
    {
        private readonly IRepository<User> _userRepository;
        public FindUserRequestHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository; 
        }
        
        public async Task<User?> HandleRequest(FindUserRequest request)
        {
            var users = await _userRepository.GetAll();
            return users.SingleOrDefault(x => x.DiscordId == request.DiscordId);
        }
    }
}

