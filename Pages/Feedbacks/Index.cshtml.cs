using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PuppyYoga.Data;
using PuppyYoga.Models;

namespace PuppyYoga.Pages.Feedbacks
{
    public class IndexModel : PageModel
    {
        private readonly PuppyYoga.Data.PuppyYogaContext _context;

        public IndexModel(PuppyYoga.Data.PuppyYogaContext context)
        {
            _context = context;
        }

        public IList<Feedback> Feedback { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Feedback != null)
            {
                Feedback = await _context.Feedback
                .Include(f => f.User)
                .Include(f => f.YogaClass).ToListAsync();
            }
        }
    }
}
