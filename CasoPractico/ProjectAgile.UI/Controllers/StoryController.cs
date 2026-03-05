using Microsoft.AspNetCore.Mvc;
using ProjectAgile.UI.Services;

namespace ProjectAgile.UI.Controllers
{
    public class StoryController : Controller
    {
        private readonly IStoryApiClient _storyApiClient;

        public StoryController(IStoryApiClient storyApiClient) => _storyApiClient = storyApiClient;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stories = await _storyApiClient.GetStoriesAsync();
            return View(stories.OrderBy(s => s.ID).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(string title, string description, string assignedTo, int estimacion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(assignedTo) || estimacion < 0)
                {
                    TempData["Error"] = "Datos inválidos.";
                    return RedirectToAction(nameof(Index));
                }
                await _storyApiClient.AddStoryAsync(title, description, assignedTo, estimacion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return BadRequest(new { message = "An error occurred while creating the story." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string newStatus)
        {
            await _storyApiClient.UpdateStoryAsync(id, newStatus, CancellationToken.None);
            return RedirectToAction(nameof(Index));
        }
    }
}
