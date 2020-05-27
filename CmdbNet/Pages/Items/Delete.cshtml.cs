using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CmdbNet.Models;

namespace CmdbNet.Pages.Items
{
    public class DeleteModel : PageModel
    {
        private readonly CmdbNet.Models.CmdbNetContext _context;

        public DeleteModel(CmdbNet.Models.CmdbNetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cmdb Cmdb { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cmdb = await _context.Cmdb
                .Include(c => c.AdRecord)
                .Include(c => c.EcmoRecord)
                .Include(c => c.EpoRecord)
                .Include(c => c.SccmRecord)
                .Include(c => c.SunflowerRecord).FirstOrDefaultAsync(m => m.CmdbID == id);

            if (Cmdb == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cmdb = await _context.Cmdb.FindAsync(id);

            if (Cmdb != null)
            {
                _context.Cmdb.Remove(Cmdb);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
