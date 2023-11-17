using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PuppyYoga.Data;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.YogaClasses
{
    public class IndexModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public IndexModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        public IList<YogaClass> YogaClass { get;set; } = default!;

        public async Task OnGetAsync()
        {
            
                YogaClass = await _context.YogaClasses
                .Include(y => y.Instructor).ToListAsync();
            
        }
    }
}
