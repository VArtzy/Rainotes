using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using app2.Model;
using app2.Data;

namespace app2.Pages.Categories;

[BindProperties]
public class CreateModel : PageModel {
    private readonly ApplicationDbContext _db;
    public Category Category { get; set; }
    public CreateModel(ApplicationDbContext db) {
        _db = db;
    }
    public void OnGet() {

    }
    public async Task<IActionResult> OnPost() {
        if (Category.Name == Category.DisplayOrder.ToString()) {
            ModelState.AddModelError(string.Empty, "Aksi dilarang: Memiliki nama dan displayOrder yang sama!");
            // ModelState.AddModelError("Category.Name", "Aksi dilarang: Memiliki nama dan displayOrder yang sama!");
        }
        if(ModelState.IsValid) {
        await _db.Category.AddAsync(Category);
        await _db.SaveChangesAsync();
        TempData["success"]="Category created successfully";
        return RedirectToPage("Index");
        }
        return Page();
    }
}