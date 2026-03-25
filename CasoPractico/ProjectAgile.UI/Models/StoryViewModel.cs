namespace ProjectAgile.UI.Models
{
    public class StoryViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AssignedTo { get; set; } 
        public int? PokeNumber { get; set; }
        public string Status { get; set; } = string.Empty;// Backlog, To Do, In Progress, Done
        //fibonacci
        public int Estimacion { get; set; }
        public string userName { get; set; }
    }
}
