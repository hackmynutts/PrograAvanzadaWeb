using ProjectAgileBoard.API.Models;

namespace ProjectAgileBoard.API.Repository
{
    public interface IStoryRepository
    {
        Task<List<Story>> GetAllStoriesAsync();
        Task<Story?> GetStoryByIdAsync(int id);
        Task AddStoryAsync(Story story);
        Task UpdateStoryAsync(Story story);
    }
}
