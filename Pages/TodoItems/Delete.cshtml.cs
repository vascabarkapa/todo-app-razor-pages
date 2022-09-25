using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoApplication_RazorPages.Data;
using ToDoApplication_RazorPages.Model;

namespace ToDoApplication_RazorPages.Pages.TodoItems
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public TodoItem TodoItem { get; set; }

        public void OnGet(int id)
        {
            TodoItem = _db.TodoItems.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (TodoItem.Priority == "")
            {
                ModelState.AddModelError("Priority", "The Priority is required.");
            }

            if (ModelState.IsValid)
            {
                _db.TodoItems.Update(TodoItem);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
