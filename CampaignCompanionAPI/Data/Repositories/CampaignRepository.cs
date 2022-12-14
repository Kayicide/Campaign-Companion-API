using Microsoft.EntityFrameworkCore;
using CampaignCompanionAPI.Data.Entities;

namespace CampaignCompanionAPI.Data.Repositories
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
            var campaign = await _context.Campaigns.FindAsync(id);
            if (campaign == null)
                return null;

            await _context.Entry(campaign).Collection(x => x.Encounters).LoadAsync();
            
            return campaign;
        }

        public async Task<List<Campaign>> GetAll()
        {
            var campaigns = await _context.Campaigns.Include(x => x.Encounters).ToListAsync();
            return campaigns;
        }

        public Task<IQueryable<Campaign>> GetAllQueryable()
        {
            var campaigns = _context.Campaigns.AsQueryable();
            return Task.FromResult(campaigns);
        }

        public async Task<Campaign?> Update(Campaign entity)
        {
            var entityToUpdate = await _context.Campaigns.FindAsync(entity.Id);
            if (entityToUpdate == null)
                return null;

            entityToUpdate.Name = entity.Name;
            entityToUpdate.Description = entity.Description;

            await _context.SaveChangesAsync();

            return entityToUpdate;
        }
    }
}
