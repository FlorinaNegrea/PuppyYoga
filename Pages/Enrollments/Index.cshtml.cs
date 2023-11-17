using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PuppyYoga.Data;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.Enrollments
{
    public class IndexModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public IndexModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        public IList<Enrollment> Enrollment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Enrollment != null)
            {
                Enrollment = await _context.Enrollment
                .Include(e => e.User)
                .Include(e => e.YogaClass).ToListAsync();
            }
        }
    }
}
