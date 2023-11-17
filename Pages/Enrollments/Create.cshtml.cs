using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PuppyYoga.Data;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public CreateModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID");
        ViewData["YogaClassID"] = new SelectList(_context.YogaClasses, "YogaClassID", "YogaClassID");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Enrollment == null || Enrollment == null)
            {
                return Page();
            }

            _context.Enrollment.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
