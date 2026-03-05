using Microsoft.EntityFrameworkCore;
using ProjectAgileBoard.API.Data;
using ProjectAgileBoard.API.Models;

namespace ProjectAgileBoard.API.Repository
{
    public class StoryRepository : IStoryRepository
    {
        private readonly AppDbContext _context;
        public StoryRepository(AppDbContext db) => _context = db;

        public async Task<List<Story>> GetAllStoriesAsync()
        {
            return await _context.Stories.AsNoTracking().ToListAsync();
        }

        public async Task<Story?> GetStoryByIdAsync(int id)
        {
            return await _context.Stories.FindAsync(id);
        }

        public async Task AddStoryAsync(Story story)
        {
            _context.Stories.Add(story);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStoryAsync(Story story)
        {
            _context.Stories.Update(story);
            await _context.SaveChangesAsync();
        }
    }
}
