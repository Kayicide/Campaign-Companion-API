namespace CampaignCompanionAPI.Data.Entities
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Initiative { get; set; }
        public int CurrentHp { get; set; }
        public int MaxHp { get; set; }
    }
}
