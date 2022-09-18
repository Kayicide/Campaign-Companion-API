using SimpleDnDTurnTracker.Data.Entities;

namespace SimpleDnDTurnTracker.Data
{
    public static class MainContextInitialise
    {
        public static void Initialise(MainContext context)
        {
            context.Database.EnsureCreated();
            if (context.Characters.Any() || context.Encounters.Any() || context.Campaigns.Any())
                return;

            var encounter = new Encounter("Encounter Test")
            {
                Id = new Guid("bc411bef-4623-49cd-b709-2c0aebb38d5b"),
            };

            context.Encounters.Add(encounter);

            var campaign = new Campaign("Campaign Test", "126445452710248449")
            {
                Encounters = new List<Encounter>
                {
                    encounter
                }
            };

            context.Campaigns.Add(campaign);

            var user = new User
            {
                Id = new Guid("1704551b-0991-46e2-a924-fe4537ccfbe0"),
                DiscordId = "126445452710248449"
            };

            context.Users.Add(user);

            context.SaveChanges();
        }

    }
}
