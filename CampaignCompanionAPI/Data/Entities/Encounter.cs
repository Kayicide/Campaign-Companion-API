namespace CampaignCompanionAPI.Data.Entities
{
    public class Encounter
    {
        public Encounter(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Round = 1;
            CreatedDateTime = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Round { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public Guid CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}
