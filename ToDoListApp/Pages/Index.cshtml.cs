using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListApp.Models;

namespace ToDoListApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        AppDbContext db;

        public List<TaskToDo> Tasks { get; set; } = new List<TaskToDo>();

        public IndexModel(AppDbContext context)
        {
            db = context;
        }

        public void OnGet()
        {
            Tasks = db.Tasks.ToList();
        }
    }
}
