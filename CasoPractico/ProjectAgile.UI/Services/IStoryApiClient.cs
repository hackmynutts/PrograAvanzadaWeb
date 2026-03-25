using ProjectAgile.UI.Models;

namespace ProjectAgile.UI.Services
{
    public interface IStoryApiClient
    {
        Task<List<StoryViewModel>> GetStoriesAsync(CancellationToken cancellationToken = default);
        Task AddStoryAsync(string title, string description, int assignedTo, int PokeNumber, CancellationToken cancellationToken = default);
        Task UpdateStoryAsync(int id, string newStatus, CancellationToken cancellationToken);
    }
}
