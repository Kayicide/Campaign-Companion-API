
using CampaignCompanionAPI.Data.Entities;
using CampaignCompanionAPI.Data.Repositories;

namespace CampaignCompanionAPI.Features.Campaigns
{
    public class CreateCampaignRequest : IRequest
    {
        public string Name { get; set; }
        public string UserId { get; set; }
    }
    public class CreateCampaignRequestHandler : IRequestHandler<CreateCampaignRequest, Campaign>
    {
        private readonly IRepository<Campaign> _campaignRepository;
        public CreateCampaignRequestHandler(IRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public async Task<Campaign> HandleRequest(CreateCampaignRequest request)
        {
            var campaign = new Campaign(request.Name, request.UserId);

            var campaignAdded = await _campaignRepository.Add(campaign);

            return campaignAdded;
        }
    }
}
