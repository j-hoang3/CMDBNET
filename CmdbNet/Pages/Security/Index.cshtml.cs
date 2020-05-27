using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CmdbNet.Models;

namespace CmdbNet.Pages.Security
{
    public class IndexModel : PageModel
    {
        private readonly CmdbNet.Models.CmdbNetContext _context;

        public IndexModel(CmdbNet.Models.CmdbNetContext context)
        {
            _context = context;
        }

        public IList<Cmdb> Cmdb { get;set; }

        public async Task<JsonResult> OnGetListAsync()
        {
            Cmdb = await _context.Cmdb
                .AsNoTracking()
                .Include(c => c.AdRecord)
                .Include(c => c.EcmoRecord)
                .Include(c => c.EpoRecord)
                .Include(c => c.SccmRecord)
                .Include(c => c.SunflowerRecord)
                .OrderBy(c => c.CdTag)
                .ToListAsync();
               

            return new JsonResult(Cmdb);
        }

    }
}
