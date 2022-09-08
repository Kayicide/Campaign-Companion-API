namespace SimpleDnDTurnTracker.Data.Entities
{
    public class Campaign
    {
        public Campaign(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Encounter>? Encounters { get; set; }
    }
}
