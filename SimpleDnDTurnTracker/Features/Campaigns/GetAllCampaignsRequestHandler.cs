using SimpleDnDTurnTracker.Data.Entities;
using SimpleDnDTurnTracker.Data.Repositories;

namespace SimpleDnDTurnTracker.Features.Campaigns
{
    public class GetAllCampaignsRequest:IRequest
    {
    }
    public class GetAllCampaignsRequestHandler:IRequestHandler<GetAllCampaignsRequest, List<Campaign>>
    {
        private readonly IRepository<Campaign> _campaignRepository;
        public GetAllCampaignsRequestHandler(IRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public async Task<List<Campaign>> HandleRequest(GetAllCampaignsRequest request)
        {
            var campaigns = await _campaignRepository.GetAll();
            return campaigns;
        }
    }
}
