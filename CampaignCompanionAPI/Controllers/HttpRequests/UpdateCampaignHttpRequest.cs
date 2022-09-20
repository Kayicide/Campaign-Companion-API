using CampaignCompanionAPI.Data.Entities;

namespace CampaignCompanionAPI.Controllers.HttpRequests
{
    public class UpdateCampaignHttpRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
