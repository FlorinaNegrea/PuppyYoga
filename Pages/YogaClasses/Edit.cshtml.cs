using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PuppyYoga.Data;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.YogaClasses
{
    public class EditModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public EditModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public YogaClass YogaClass { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yogaClass = await _context.YogaClasses
                .Include(y => y.Instructor)
                .FirstOrDefaultAsync(m => m.YogaClassID == id);

            if (yogaClass == null)
            {
                return NotFound();
            }

            YogaClass = yogaClass;

            ViewData["InstructorId"] = new SelectList(_context.Set<Instructor>(), "InstructorId", "FullName");

            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(YogaClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YogaClassExists(YogaClass.YogaClassID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool YogaClassExists(int id)
        {
          return (_context.YogaClasses?.Any(e => e.YogaClassID == id)).GetValueOrDefault();
        }
    }
}
