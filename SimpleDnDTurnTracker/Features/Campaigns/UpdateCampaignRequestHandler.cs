using SimpleDnDTurnTracker.Data.Entities;
using SimpleDnDTurnTracker.Data.Repositories;

namespace SimpleDnDTurnTracker.Features.Campaigns
{
    public class UpdateCampaignRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCampaignRequestHandler : IRequestHandler<UpdateCampaignRequest, Campaign?>
    {
        private readonly IRepository<Campaign> _campaignRepository;
        public UpdateCampaignRequestHandler(IRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public async Task<Campaign?> HandleRequest(UpdateCampaignRequest request)
        {
            var campaign = new Campaign(request.Id, request.Name);

            campaign = await _campaignRepository.Update(campaign);

            return campaign;
        }
    }
}
