using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PuppyYoga.Data;
using PuppyYoga.Models;
namespace PuppyYoga.Pages.YogaClasses
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public CreateModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
          
        }

        public IActionResult OnGet()
        {

            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "FullName");
            return Page();
        }


        [BindProperty]
        public YogaClass YogaClass { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.YogaClasses == null || YogaClass == null)
            {
                return Page();
            }
            _context.YogaClasses.Add(YogaClass);
            await _context.SaveChangesAsync();
            return RedirectToAction("./Index");
        }


    }
}
