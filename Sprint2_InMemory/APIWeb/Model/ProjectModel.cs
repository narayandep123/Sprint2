namespace APIWeb.Model
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; }

        public ProjectModel(int id, string name, string detail, DateTime createdOn)
        {
            Id = id;
            Name = name;
            Detail = detail;
            CreatedOn = createdOn;
        }
    }
}
