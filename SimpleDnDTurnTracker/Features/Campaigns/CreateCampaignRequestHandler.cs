﻿
using SimpleDnDTurnTracker.Data.Entities;
using SimpleDnDTurnTracker.Data.Repositories;

namespace SimpleDnDTurnTracker.Features.Campaigns
{
    public class CreateCampaignRequest : IRequest
    {
        public string Name { get; set; }
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
            var campaign = new Campaign(request.Name);

            var campaignAdded = await _campaignRepository.Add(campaign);

            return campaignAdded;
        }
    }
}