namespace SimpleDnDTurnTracker.Data.Entities
{
    public class Campaign
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Encounter>? Encounters { get; set; }
    }
}
