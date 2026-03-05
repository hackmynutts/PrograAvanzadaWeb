using ProjectAgile.UI.Models;
using ProjectAgileBoard.API.Models;

namespace ProjectAgile.UI.Services
{
    public class StoryApiClient : IStoryApiClient
    {
        private readonly HttpClient _httpClient;

        public StoryApiClient(HttpClient httpClient) => _httpClient = httpClient;

        //List Stories
        public async Task<List<StoryViewModel>> GetStoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetFromJsonAsync<List<StoryViewModel>>("api/Story", cancellationToken)
                ?? new List<StoryViewModel>();
        }

        //add story
        public async Task AddStoryAsync(string title, string description, string assignedTo, int estimacion, CancellationToken cancellationToken = default)
        {
            var story = new StoryViewModel
            {
                Title = title,
                Description = description,
                AssignedTo = assignedTo,
                Estimacion = estimacion,
                Status = Status.Backlog.ToString()
            };
            var response = await _httpClient.PostAsJsonAsync("api/Story", story, cancellationToken = default);
            response.EnsureSuccessStatusCode();
        }

        //update story
        public async Task UpdateStoryAsync(int id, string newStatus, CancellationToken cancellationToken = default)
        {
            // 1) traer story actual (para no perder campos)
            var story = await _httpClient.GetFromJsonAsync<StoryViewModel>($"api/Story/{id}", cancellationToken);
            if (story == null) throw new Exception("Story no encontrada");

            // 2) cambiar status
            story.Status = newStatus;

            // 3) post al endpoint real
            var resp = await _httpClient.PostAsJsonAsync($"api/Story/update/{id}", story, cancellationToken);
            resp.EnsureSuccessStatusCode();
        }
    }
}
