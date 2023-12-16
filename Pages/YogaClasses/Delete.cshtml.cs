using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PuppyYoga.Data;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.YogaClasses
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public DeleteModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public YogaClass YogaClass { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.YogaClasses == null)
            {
                return NotFound();
            }

            var yogaclass = await _context.YogaClasses.Include(b => b.Instructor).FirstOrDefaultAsync(m => m.YogaClassID == id);

            if (yogaclass == null)
            {
                return NotFound();
            }
            else 
            {
                YogaClass = yogaclass;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.YogaClasses == null)
            {
                return NotFound();
            }
            var yogaclass = await _context.YogaClasses.FindAsync(id);

            if (yogaclass != null)
            {
                YogaClass = yogaclass;
                _context.YogaClasses.Remove(YogaClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
