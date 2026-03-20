namespace ProjectAgile.UI.Models
{
    public class AgileBoardViewModel
    {
        public List<BoardColumnViewModel> Columns { get; set; } = new();
        public List<UserViewModel> Users { get; set; } = new();
    }
}
