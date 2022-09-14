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
        }
        public Campaign(Guid id, string name, string creatorId)
        {
            Id = id;
            Name = name;
            CreatorId = creatorId;
        }
        public Campaign(Guid id, string name)
        {
            Id = id;
            Name = name;
            CreatorId = "";
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreatorId { get; set; }
        public List<Encounter>? Encounters { get; set; }
    }
}
