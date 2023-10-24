using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Buliga_Rares_Lab2.Data;
using Buliga_Rares_Lab2.Models;

namespace Buliga_Rares_Lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Buliga_Rares_Lab2.Data.Buliga_Rares_Lab2Context _context;

        public CreateModel(Buliga_Rares_Lab2.Data.Buliga_Rares_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "FirstName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");

            // Include Author based on your lab requirements
            // You can add this block to include Author
            /*
            ViewData["AuthorID"] = new SelectList(_context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            }), "ID", "FullName");
            */


            // Initialize the AssignedCategoryDataList
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = new Book(); // Ensure Book is initialized

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            if (selectedCategories == null)
            {
                ModelState.AddModelError("Book.BookCategories", "Please select at least one category.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Add the Book to the context
            _context.Book.Add(Book);

            // Include the BookCategories based on your lab requirements
            if (selectedCategories != null)
            {
                Book.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    BookCategory catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    Book.BookCategories.Add(catToAdd);
                }
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
