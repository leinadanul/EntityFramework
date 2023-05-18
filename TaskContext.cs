// este es la configuracion de instalacion de entity framework


using Microsoft.EntityFrameworkCore;
using projectef.Model;
using Task = projectef.Model.Task;

namespace projectef;

public class TaskContext : DbContext
{
    public DbSet<Category> Categories { get; set;}
    public DbSet<Task> Tasks { get; set;}

    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category(){CategoryId = Guid.Parse("ea9301c2-0dfd-45e6-ae1a-491c67eed101"), Name = "Task to do", Weight = 20});
        categoriesInit.Add(new Category(){CategoryId = Guid.Parse("ea9301c2-0dfd-45e6-ae1a-491c67eed102"), Name = "Personal task", Weight = 50});
        

        modelBuilder.Entity<Category>(Category =>  
        {
            Category.ToTable("Category");

            Category.HasKey(p=>p.CategoryId);

            Category.Property(p=> p.Name).IsRequired().HasMaxLength(150);

            Category.Property(p=> p.Description).IsRequired(false);

            Category.Property(p=> p.Weight);

            Category.HasData(categoriesInit);
        });

        List<Task> tasksInit = new List<Task>();
        tasksInit.Add(new Task() {TaskId = Guid.Parse("ea9301c2-0dfd-45e6-ae1a-491c67eed110"), CategoryId = Guid.Parse("ea9301c2-0dfd-45e6-ae1a-491c67eed101"), TaskPrority = Priority.Medium, Title= "Pay public Services",DateCreation= DateTime.Now});
        tasksInit.Add(new Task() {TaskId = Guid.Parse("ea9301c2-0dfd-45e6-ae1a-491c67eed111"), CategoryId = Guid.Parse("ea9301c2-0dfd-45e6-ae1a-491c67eed102"), TaskPrority = Priority.Low, Title= "Finish watching the movie",DateCreation= DateTime.Now});

        modelBuilder.Entity<Task>(task=>
        {
            task.ToTable("Task");
            task.HasKey(p=> p.TaskId);

            task.HasOne(p=> p.Category).WithMany(p=> p.Tasks).HasForeignKey(p=> p.CategoryId);

            task.Property(p=> p.Title).IsRequired().HasMaxLength(200);

            task.Property(p=> p.Description).IsRequired(false);

            task.Property(p=> p.TaskPrority);

            task.Property(p=> p.DateCreation);

            task.Ignore(p=> p.Summary);

            task.HasData(tasksInit);

        });
    }

    


}