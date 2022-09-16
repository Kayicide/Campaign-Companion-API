using SimpleDnDTurnTracker.Data.Entities;

namespace SimpleDnDTurnTracker.Controllers.HttpRequests
{
    public class UpdateCampaignHttpRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
