using System;
using Microsoft.EntityFrameworkCore;
using CampaignCompanionAPI.Data.Entities;

namespace CampaignCompanionAPI.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly MainContext _context;
        public UserRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User?> Get(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<IQueryable<User>> GetAllQueryable()
        {
            var users = _context.Users.AsQueryable();
            return Task.FromResult(users);
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}

