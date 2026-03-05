namespace ProjectAgileBoard.API.Models
{
    public enum Status
    {
        Backlog,
        ToDo,
        InProgress,
        Done
    }
    public class Story
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string AssignedTo { get; set; }
        public Status Status { get; set; }// Backlog, To Do, In Progress, Done
        //fibonacci
        public int Estimacion { get; set; }
    }
}
