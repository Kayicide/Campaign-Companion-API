using CampaignCompanionAPI.Data.Entities;
using CampaignCompanionAPI.Data.Repositories;

namespace CampaignCompanionAPI.Features.Campaigns
{
    public class GetCampaignRequest : IRequest
    {
        public Guid CampaignId { get; set; }
    }
    public class GetCampaignRequestHandler : IRequestHandler<GetCampaignRequest, Campaign?>
    {
        private readonly IRepository<Campaign> _campaignRepository;
        public GetCampaignRequestHandler(IRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public async Task<Campaign?> HandleRequest(GetCampaignRequest request)
        {
            var campaign = await _campaignRepository.Get(request.CampaignId);
            return campaign;

        }
    }
}
