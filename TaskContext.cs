// este es la configuracion de instalacion de entity framework


using Microsoft.EntityFrameworkCore;
using projectef.Model;
using Task = projectef.Model.Task;

namespace projectef;

public class TaskContex : DbContext
{
    public DbSet<Category> Categories { get; set;}
    public DbSet<Task> Tasks { get; set;}

    public TaskContex(DbContextOptions<TaskContex> options) : base(options) { }
}