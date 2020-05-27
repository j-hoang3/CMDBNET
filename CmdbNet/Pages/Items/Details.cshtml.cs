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
    public class DetailsModel : PageModel
    {
        private readonly CmdbNet.Models.CmdbNetContext _context;

        public DetailsModel(CmdbNet.Models.CmdbNetContext context)
        {
            _context = context;
        }

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
    }
}
