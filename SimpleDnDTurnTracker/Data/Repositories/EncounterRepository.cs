using SimpleDnDTurnTracker.Data.Entities;

namespace SimpleDnDTurnTracker.Data.Repositories
{
    public class EncounterRepository : IRepository<Encounter>
    {
        private readonly MainContext _context;
        public EncounterRepository(MainContext context)
        {
            _context = context;
        }
        public async Task<Encounter> Add(Encounter entity)
        {
            await _context.Encounters.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Encounter?> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Encounter>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Encounter?> Update(Encounter entity)
        {
            var encounter = await _context.Encounters.FindAsync(entity.Id);
            if (encounter == null)
                return null;

            if (!string.IsNullOrEmpty(entity.Name))
                encounter.Name = entity.Name;

            if(entity.Round > encounter.Round)
                encounter.Round = entity.Round;

            await _context.SaveChangesAsync();

            return encounter;
        }
    }
}
