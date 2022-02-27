namespace APIWeb.Model
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int Status { get; set; }
        public int AssignedToUserID { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; }

        public TaskModel(int id, int projectId, int status, int assignedToUserID, string detail, DateTime createdOn)
        {
            Id = id;
            ProjectId = projectId;
            Status = status;
            AssignedToUserID = assignedToUserID;
            Detail = detail;
            CreatedOn = createdOn;
        }
    }
}
