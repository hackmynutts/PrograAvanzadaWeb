using ProjectAgileBoard.API.DTO;
using ProjectAgileBoard.API.Models;
using ProjectAgileBoard.API.Repository;
using ProjectAgileBoard.API.Strategy;

namespace ProjectAgileBoard.API.Services
{
    public class StoryServices : IStoryServices
    {
        private readonly IStoryRepository _repository;
        private readonly IEstimationStrategyFactory _factory; // inyección de la fábrica

        public StoryServices(IStoryRepository repository, IEstimationStrategyFactory factory) 
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<List<StoryDTO>> GetAllStoriesAsync()
        {
            var stories = await _repository.GetAllStoriesAsync();
            return stories.Select(s => new StoryDTO
            {
                ID = s.ID,
                Title = s.Title,
                Description = s.Description,
                AssignedTo = s.AssignedTo,
                Status = s.Status.ToString(),
                Estimacion = s.Estimacion
            }).ToList();
        }

        public async Task<StoryDTO?> GetStoryByIdAsync(int id)
        {
            var story = await _repository.GetStoryByIdAsync(id);
            if (story == null) return null;
            return new StoryDTO
            {
                ID = story.ID,
                Title = story.Title,
                Description = story.Description,
                AssignedTo = story.AssignedTo,
                Status = story.Status.ToString(),
                Estimacion = story.Estimacion
            };
        }

        public async Task<StoryDTO> CreateStoryAsync(StoryDTO storyDto)
        {
            var story = new Story
            {
                Title = storyDto.Title,
                Description = storyDto.Description,
                AssignedTo = storyDto.AssignedTo,
                Status = Status.Backlog,
                Estimacion = await _factory.GetStrategy("fibonacci").GetEstimationAsync() // uso la estrategia de Fibonacci para la estimación inicial
            };
            await _repository.AddStoryAsync(story);
            return new StoryDTO
            {
                ID = story.ID,
                Title = story.Title,
                Description = story.Description,
                AssignedTo = story.AssignedTo,
                Status = story.Status.ToString(),
                Estimacion = story.Estimacion
            };
        }

        public async Task<StoryDTO?> UpdateStoryAsync(int id, StoryDTO storyDto)
        {
            var existingStory = await _repository.GetStoryByIdAsync(id);
            if (existingStory == null) return null;

            existingStory.Title = storyDto.Title;
            existingStory.Description = storyDto.Description;
            existingStory.AssignedTo = storyDto.AssignedTo;
            existingStory.Status = Enum.Parse<Status>(storyDto.Status);
            existingStory.Estimacion = await _factory.GetStrategy("random").GetEstimationAsync(); // uso la estrategia de Random para la actualización de la estimación

            await _repository.UpdateStoryAsync(existingStory);
            return new StoryDTO
            {
                ID = existingStory.ID,
                Title = existingStory.Title,
                Description = existingStory.Description,
                AssignedTo = existingStory.AssignedTo,
                Status = existingStory.Status.ToString(),
                Estimacion = existingStory.Estimacion
            };
        }
    }
}