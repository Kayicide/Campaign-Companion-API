using Microsoft.EntityFrameworkCore;
using CampaignCompanionAPI.Data.Entities;
using CampaignCompanionAPI.Data.Repositories;

namespace CampaignCompanionAPI.Features.Campaigns
{
    public class GetCampaignsWithUserIdRequest : IRequest
    {
        public string UserId { get; set; }
    }
    public class GetCampaignsWithUserIdRequestHandler : IRequestHandler<GetCampaignsWithUserIdRequest, List<Campaign>>
    {
        private readonly IRepository<Campaign> _campaignRepository;
        public GetCampaignsWithUserIdRequestHandler(IRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<List<Campaign>> HandleRequest(GetCampaignsWithUserIdRequest request)
        {
            var campaigns = await _campaignRepository.GetAllQueryable();
            var userCampaigns = await campaigns.Where(x => x.CreatorId == request.UserId).Include(x => x.Encounters).ToListAsync();
            return userCampaigns;
        }
    }
}
