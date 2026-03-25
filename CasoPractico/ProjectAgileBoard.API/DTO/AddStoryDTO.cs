namespace ProjectAgileBoard.API.DTO
{
    public class AddStoryDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AssignedTo { get; set; }
    }
}
