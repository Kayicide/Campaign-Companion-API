namespace SimpleDnDTurnTracker.Data.Entities
{
    public class Campaign
    {
        public Campaign() { }

        public Campaign(string name, string creatorId)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatorId = creatorId;
            Description = "A brand new campaign!";
        }
        public Campaign(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatorId { get; set; }
        public List<Encounter>? Encounters { get; set; }
    }
}
