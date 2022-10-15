using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public Category? Category { get; set; }
        private readonly AplicationDbContext _db;

        public DeleteModel(AplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category!.Find(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {

                var categoryFromDb = _db.Category!.Find(Category!.Id);
                if(categoryFromDb != null)
                {
                    _db.Category.Remove(categoryFromDb!);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
                }
                
                return Page();
            
        }
    }
}
