namespace SimpleDnDTurnTracker.Controllers.HttpRequests
{
    public class CreateEncounterHttpRequest
    {
        public Guid CampaignId { get; set; }
        public string Name { get; set; }
    }
}
