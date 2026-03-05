using Microsoft.AspNetCore.Mvc;
using ProjectAgileBoard.API.DTO;
using ProjectAgileBoard.API.Services;

namespace ProjectAgileBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : Controller
    {
        private readonly IStoryServices _services;
        public StoryController(IStoryServices services) => _services = services;

        [HttpGet]
        public async Task<IEnumerable<StoryDTO>> Get() => await _services.GetAllStoriesAsync(); // Return all stories


        [HttpGet("{id}")]
        public async Task<ActionResult<StoryDTO>> Get(int id)
        {
            var story = await _services.GetStoryByIdAsync(id);
            return story is not null ? Ok(story) : NotFound(); // Return story by ID or 404 if not found
        }

        [HttpPost]
        public async Task<ActionResult<StoryDTO>> Create(AddStoryDTO storyDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); // Validate input 
            var createdStory = await _services.CreateStoryAsync(new StoryDTO
            {
                Title = storyDto.Title,
                Description = storyDto.Description,
                AssignedTo = storyDto.AssignedTo
            });
            return CreatedAtAction(nameof(Get), new { id = createdStory.ID }, createdStory); // Return created story with 201 status
        }
        [HttpPost("update/{id}")]
        public async Task<ActionResult<StoryDTO>> Update(int id, StoryDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _services.UpdateStoryAsync(id, dto);
            if (updated == null) return NotFound();

            return Ok(updated);
        }
    }
}
