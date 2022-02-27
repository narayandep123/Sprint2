using Microsoft.EntityFrameworkCore;

namespace APIWeb.Model
{
    public class Sprint2DBContext: DbContext
    {
        //public Sprint2DBContext(DbContextOptions<Sprint2DBContext> options): base(options)
        //{

        //}
        //public DbSet<Category> Categories { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }

        public Sprint2DBContext(DbContextOptions<Sprint2DBContext> options)
        : base(options)
        {
           // LoadCategories();
        }
        //public Sprint2DBContext(DbContextOptions options) : base(options)
        //{
        //    LoadCategories();
        //}

        public void LoadCategories()
        {
            UserModel category = new UserModel() { Id=1, Password="123", LastName="lohra", FirstName = "Category1" };
            Users.Add(category);
            category = new UserModel() { Id = 1, Password = "123", LastName = "lohra", FirstName = "Category2" };
            Users.Add(category);
        }

        public List<UserModel> GetCategories()
        {
            return Users.Local.ToList<UserModel>();
        }
    }
}
