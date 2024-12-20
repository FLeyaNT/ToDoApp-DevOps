using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
});

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
string connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User Id=sa;Password={dbPassword};TrustServerCertificate=True;";

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapRazorPages();

app.UseStaticFiles();

app.MapPost("/Index/Add", async (HttpContext context, AppDbContext db) =>
{
    TaskToDo task = new TaskToDo
    {
        Id = Guid.NewGuid(),
        Description = context.Request.Form["desc"],
        Done = false,
    };

    await db.Tasks.AddAsync(task);
    await db.SaveChangesAsync();

    context.Response.Redirect("/");
});

app.MapPost("/Index/Edit", async (HttpContext context, AppDbContext db) =>
{
    string? idString = context.Request.Form["id"];

    if (!string.IsNullOrEmpty(idString))
    {
        TaskToDo? task = await db.Tasks.FirstAsync(x => x.Id == Guid.Parse(idString));

        task.Description = context.Request.Form["desc"];

        await db.SaveChangesAsync();
    }
        
    context.Response.Redirect("/");
});

app.MapPost("/Index/Del", async (HttpContext context, AppDbContext db) =>
{
    string? idString = context.Request.Form["id"];

    if (!string.IsNullOrEmpty(idString))
    {
        TaskToDo? task = await db.Tasks.FirstOrDefaultAsync(x => x.Id == Guid.Parse(idString));

        if (task != null)
        {
            db.Tasks.Remove(task);
            await db.SaveChangesAsync();
        }
    }

    context.Response.Redirect("/");
});


app.Run();
