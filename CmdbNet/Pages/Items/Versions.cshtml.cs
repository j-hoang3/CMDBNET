using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CmdbNet.Models;
using System.Data.SqlClient;

namespace CmdbNet.Pages.Items
{
    public class VersionsModel : PageModel
    {
        private readonly CmdbNet.Models.CmdbNetContext _context;

        public VersionsModel(CmdbNet.Models.CmdbNetContext context)
        {
            _context = context;
        }

        public IList<Cmdb> Versions = null;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = id;

            Versions = await _context.Cmdb
                .FromSql($"SELECT * FROM dbo.Cmdb FOR SYSTEM_TIME ALL WHERE CmdbID = {{0}} Order By Modified DESC", item)
                .AsNoTracking()
                .ToListAsync();

            if (Versions == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public Cmdb Cmdb { get; set; }

        [HttpPost]
        public async Task<IActionResult> OnPostRestoreVersionAsync(Cmdb item)
        {
            string dateString;
            DateTime dateValue;

            string currentUser = HttpContext.User.Identity.Name;
            currentUser = currentUser.Remove(0, 4).Replace('.', ' ');

            dateString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dateValue = DateTime.Parse(dateString);

            Cmdb = item;
            Cmdb.Modified = dateValue;
            Cmdb.ModifiedBy = currentUser;

            _context.Attach(Cmdb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CmdbExists(Cmdb.CmdbID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Index");
        }

        private bool CmdbExists(int id)
        {
            return _context.Cmdb.Any(e => e.CmdbID == id);
        }
    }
}
