using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using app2.Model;
using app2.Data;

namespace app2.Pages.Categories;

[BindProperties]
public class EditModel : PageModel {
    private readonly ApplicationDbContext _db;
    public Category Category { get; set; }
    public EditModel(ApplicationDbContext db) {
        _db = db;
    }
    public void OnGet(int id) {
        Category = _db.Category.Find(id);
        // Category = _db.Category.SingleOrDefault(u=>u.Id==id);
        // Category = _db.Category.FirstOrDefault(u=>u.Id==id);
        // Category = _db.Category.here(u=>u.Id==id).FirstOrDefault();
    }

    public async Task<IActionResult> OnPost() {
        if (Category.Name == Category.DisplayOrder.ToString()) {
            ModelState.AddModelError(string.Empty, "Aksi dilarang: Memiliki nama dan displayOrder yang sama!");
            // ModelState.AddModelError("Category.Name", "Aksi dilarang: Memiliki nama dan displayOrder yang sama!");
        }
        if(ModelState.IsValid) {
        _db.Category.Update(Category);
        await _db.SaveChangesAsync();
        TempData["success"]="Category updated successfully";
        return RedirectToPage("Index");
        }
        return Page();
    }
}