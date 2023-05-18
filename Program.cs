using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;
using projectef.Model;
var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TaskDB"));
builder.Services.AddSqlServer<TaskContext> (builder.Configuration.GetConnectionString("cnTask"));
//builder.Services.AddSqlServer<TaskContext> (builder.Configuration.GetConnectionString("taskDb2"));



var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async([FromServices] TaskContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory :" + dbContext.Database.IsInMemory());
});
app.MapGet("/api/task", async ([FromServices] TaskContext dbContext) => 
{
    return Results.Ok(dbContext.Tasks.Include(p=> p.Category));

    //return Results.Ok(dbContext.Tasks.Include(p=> p.Category).Where(p=> p.TaskPrority == projectef.Model.Priority.Low));
});


app.MapPost("/api/task", async ([FromServices] TaskContext dbContext, [FromBody] projectef.Model.Task task) => 
{
    task.TaskId = Guid.NewGuid();
    task.DateCreation = DateTime.Now;
    await dbContext.AddAsync(task);

    await dbContext.SaveChangesAsync();




    return Results.Ok();
});

app.Run();
