using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CmdbNet.Models;

namespace CmdbNet.Pages.Hardware
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
            string currentUser = HttpContext.User.Identity.Name;
            currentUser = currentUser.Remove(0, 4).Replace('.', ' ').ToLower();

            Cmdb = await _context.Cmdb
                .Where(i => i.AdUser.ToLower().Contains(currentUser))
                .AsNoTracking()
                .ToListAsync();

            return new JsonResult(Cmdb);
        }
    }
}
