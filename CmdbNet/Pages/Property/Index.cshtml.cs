using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CmdbNet.Models;

namespace CmdbNet.Pages.Property
{
    public class IndexModel : PageModel
    {
        private readonly CmdbNet.Models.CmdbNetContext _context;

        public IndexModel(CmdbNet.Models.CmdbNetContext context)
        {
            _context = context;
        }

        public IList<Sunflower> Sunflower { get;set; }

        public async Task<JsonResult> OnGetListAsync()
        {
            Sunflower = await _context.Sunflower
                .Include(s => s.CmdbRecord)
                .AsNoTracking()
                .ToListAsync();

            return new JsonResult(Sunflower);
        }
    }
}
