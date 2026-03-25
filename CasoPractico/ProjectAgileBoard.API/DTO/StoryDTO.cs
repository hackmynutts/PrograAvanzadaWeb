namespace ProjectAgileBoard.API.DTO
{
    public class StoryDTO
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AssignedTo { get; set; }
        public int? PokeNumber { get; set; }
        public string Status { get; set; }// Backlog, To Do, In Progress, Done
        //fibonacci
        public int Estimacion { get; set; }
    }
}
