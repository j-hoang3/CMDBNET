using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CmdbNet.Models;
using Microsoft.EntityFrameworkCore;

namespace CmdbNet.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly CmdbNet.Models.CmdbNetContext _context;

        public CreateModel(CmdbNet.Models.CmdbNetContext context)
        {
            _context = context;
        }

        public string[] AdNames { get; set; }

        public IActionResult OnGet()
        {
            AdNames = _context.Ad
                    .Select(x => x.Description)
                    .ToArray();

            AdNames = AdNames.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            ViewData["AdID"] = new SelectList(_context.Ad, "AdID", "AdID");
            ViewData["EcmoID"] = new SelectList(_context.Ecmo, "EcmoID", "EcmoID");
            ViewData["EpoID"] = new SelectList(_context.Epo, "EpoID", "EpoID");
            ViewData["SccmID"] = new SelectList(_context.Sccm, "SccmID", "SccmID");
            ViewData["SunflowerID"] = new SelectList(_context.Sunflower, "SunflowerID", "SunflowerID");
            return Page();
        }

        [BindProperty]
        public Cmdb Cmdb { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            string dateString;
            DateTime dateValue;

            string currentUser = HttpContext.User.Identity.Name;
            currentUser = currentUser.Remove(0, 4).Replace('.', ' ');

            if (!ModelState.IsValid)
            {
                return Page();
            }

            dateString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dateValue = DateTime.Parse(dateString);

            Cmdb.Modified = dateValue;
            Cmdb.ModifiedBy = currentUser;

            _context.Cmdb.Add(Cmdb);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}