namespace ProjectAgile.UI.Models
{
    public class BoardColumnViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<StoryViewModel> Stories { get; set; } = new();
        public List<UserViewModel> Users { get; set; } = new();
    }
}