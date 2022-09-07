namespace SimpleDnDTurnTracker.Features.Campaign
{
    public class CreateCampaignRequest : IRequest
    {

    }
    public class CreateCampaignRequestHandler : IRequestHandler<CreateCampaignRequest, bool>
    {
        public CreateCampaignRequestHandler()
        {

        }
        public Task<bool> HandleRequest(CreateCampaignRequest request)
        {
            return Task.FromResult(true);
        }
    }
}
