using System;
namespace SimpleDnDTurnTracker.Data.Entities
{
    public class User
    {
        public User() { }
        public User(string discordId)
        {
            Id = Guid.NewGuid();
            DiscordId = discordId;
        }
        public Guid Id { get; set; }
        public string DiscordId { get; set; }
    }
}

