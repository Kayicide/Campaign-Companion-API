namespace CampaignCompanionAPI.Features
{
    public interface IRequestHandler<in TRequest, TReturn>
    {
        public Task<TReturn> HandleRequest(TRequest request);
    }
}
