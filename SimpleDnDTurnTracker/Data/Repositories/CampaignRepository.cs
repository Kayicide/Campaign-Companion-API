using Microsoft.EntityFrameworkCore;
using SimpleDnDTurnTracker.Data.Entities;

namespace SimpleDnDTurnTracker.Data.Repositories
{
    public class CampaignRepository : IRepository<Campaign>
    {
        private readonly MainContext _context;
        public CampaignRepository(MainContext context)
        {
            _context = context;
        }
        public async Task<Campaign> Add(Campaign entity)
        {
            await _context.Campaigns.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Remove(Guid id)
        {
            var campaign = await _context.Campaigns.FindAsync(id);

            if (campaign == null)
                return false;

            _context.Campaigns.Remove(campaign);

            return true;
        }

        public async Task<Campaign?> Get(Guid id)
        {
            var campaign = await _context.Campaigns.SingleOrDefaultAsync(x => x.Id == id);
            return campaign;
        }

        public async Task<List<Campaign>> GetAll()
        {
            var campaigns = await _context.Campaigns.Include(x => x.Encounters).ToListAsync();
            return campaigns;
        }

        public async Task<Campaign?> Update(Campaign entity)
        {
            var entityToUpdate = await _context.Campaigns.FindAsync(entity.Id);
            if (entityToUpdate == null)
                return null;

            entityToUpdate.Name = entity.Name;

            await _context.SaveChangesAsync();

            return entityToUpdate;
        }
    }
}
