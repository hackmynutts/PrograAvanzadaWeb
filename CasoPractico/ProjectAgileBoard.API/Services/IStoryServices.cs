using ProjectAgileBoard.API.DTO;

namespace ProjectAgileBoard.API.Services
{
    public interface IStoryServices
    {
        Task<List<StoryDTO>> GetAllStoriesAsync();
        Task<StoryDTO?> GetStoryByIdAsync(int id);
        Task<StoryDTO> CreateStoryAsync(StoryDTO storyDto);
        Task<StoryDTO?> UpdateStoryAsync(int id, StoryDTO storyDto);
    }
}
