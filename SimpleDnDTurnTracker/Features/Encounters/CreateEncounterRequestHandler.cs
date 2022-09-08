using SimpleDnDTurnTracker.Data.Entities;
using SimpleDnDTurnTracker.Data.Repositories;

namespace SimpleDnDTurnTracker.Features.Encounters
{
    public class CreateEncounterRequest : IRequest
    {
        public Guid CampaignId { get; set; }
        public string Name { get; set; }
    }
    public class CreateEncounterRequestHandler : IRequestHandler<CreateEncounterRequest, Encounter?>
    {
        private readonly IRepository<Encounter> _encounterRepository;
        private readonly IRepository<Campaign> _campaignRepository;
        public CreateEncounterRequestHandler(IRepository<Encounter> encounterRepository, IRepository<Campaign> campaignRepository)
        {
            _encounterRepository = encounterRepository;
            _campaignRepository = campaignRepository;
        }
        public async Task<Encounter?> HandleRequest(CreateEncounterRequest request)
        {
            var campaign = await _campaignRepository.Get(request.CampaignId);
            if (campaign == null)
                return null;

            var encounter = new Encounter(request.Name){Campaign = campaign, CampaignId = campaign.Id};
            encounter = await _encounterRepository.Add(encounter);

            return encounter;
        }
    }
}
