using Gym.Domain.Entities;
using Gym.Domain.Interfaces;
using Gym.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gym.Infra.Data.Repositories
{
    public class GymRepository : IGymRepository
    {
        private readonly ApplicationDbContext _context;

        public GymRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Domain.Entities.Gym>> GetAllAsync()
        {
            return await _context.Gyms.ToListAsync();
        }

        public async Task<Domain.Entities.Gym> GetById(Guid id)
        {
            var gym = await _context.Gyms.FirstOrDefaultAsync(x => x.Id == id);
            return gym;
        }

        public async Task<Domain.Entities.Gym> CreateAsync(Domain.Entities.Gym entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Domain.Entities.Gym> UpdateAsync(Domain.Entities.Gym entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Domain.Entities.Gym> DeleteAsync(Domain.Entities.Gym entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
