namespace BookListRazor.Pages.BookList
{
    using BookListRazor.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task OnGet()
        {
            this.Books = await this.db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await this.db.Book.FindAsync(id);
            if (book == null)
            {
                return this.NotFound();
            }

            this.db.Book.Remove(book);
            await this.db.SaveChangesAsync();

            this.Message = "Book delete successfully";

            return this.RedirectToPage("Index");
        }
    }
}