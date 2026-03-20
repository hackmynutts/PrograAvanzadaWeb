using Microsoft.AspNetCore.Mvc;
using ProjectAgile.UI.Models;
using ProjectAgile.UI.Services;

namespace ProjectAgile.UI.Controllers
{
    public class StoryController : Controller
    {
        private readonly IStoryApiClient _storyApiClient;
        private readonly IUserApiClient _userApiClient;

        public StoryController(IStoryApiClient storyApiClient, IUserApiClient userApiClient)
        {
            _storyApiClient = storyApiClient;
            _userApiClient = userApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stories = await _storyApiClient.GetStoriesAsync();
            var users = await _userApiClient.GetUsersAsync();

            var backlog = stories.Where(s => s.Status == "Backlog").OrderBy(s => s.ID).ToList();
            var todo = stories.Where(s => s.Status == "ToDo").OrderBy(s => s.ID).ToList();
            var inprogress = stories.Where(s => s.Status == "InProgress").OrderBy(s => s.ID).ToList();
            var done = stories.Where(s => s.Status == "Done").OrderBy(s => s.ID).ToList();

            var vm = new AgileBoardViewModel
            {
                Users = users.OrderBy(u => u.Nombre).ToList(),
                Columns = new List<BoardColumnViewModel>
                {
                    new BoardColumnViewModel
                    {
                        Title = "Backlog",
                        Status = "Backlog",
                        Stories = backlog
                    },
                    new BoardColumnViewModel
                    {
                        Title = "To Do",
                        Status = "ToDo",
                        Stories = todo
                    },
                    new BoardColumnViewModel
                    {
                        Title = "In Progress",
                        Status = "InProgress",
                        Stories = inprogress
                    },
                    new BoardColumnViewModel
                    {
                        Title = "Done",
                        Status = "Done",
                        Stories = done
                    }
                }
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string title, string description, string assignedTo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(assignedTo))
                {
                    TempData["Error"] = "Datos inválidos.";
                    return RedirectToAction(nameof(Index));
                }
                await _storyApiClient.AddStoryAsync(title, description, assignedTo);
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
