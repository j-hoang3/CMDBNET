using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmdbNet.Models;
using MimeKit;
using static System.Net.WebRequestMethods;
using MailKit.Net.Smtp;
using System.Text;

namespace CmdbNet.Pages.Items
{
    public class EditModel : PageModel
    {
        private readonly CmdbNet.Models.CmdbNetContext _context;

        public EditModel(CmdbNet.Models.CmdbNetContext context)
        {
            _context = context;
        }

        public string[] AdNames { get; set; }
        public IList<Cmdb> Versions = null;

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

            _context.Attach(Cmdb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                //Send Update Notification Email to Custodian
                if (Cmdb.Custodian != null)
                {
                    var custodian = Cmdb.Custodian;
                    custodian = custodian.Replace(' ', '.') + "@noaa.gov";

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("CMDB\u207A", "saron.desta@noaa.gov"));
                    message.To.Add(new MailboxAddress(Cmdb.Custodian, custodian));
                    message.Subject = "Record Update";
                    var url = "http://ocs-vs-webd1:5000/Items/Details/" + Cmdb.CmdbID;

                    //Find difference between current & previous version
                    

                    var id = Cmdb.CmdbID;
                    
                    Versions = await _context.Cmdb
                        .FromSql($"SELECT TOP 2 * FROM dbo.Cmdb FOR SYSTEM_TIME ALL WHERE CmdbID = {{0}} Order By Modified DESC", id)
                        .AsNoTracking()
                        .ToListAsync();

                    var newVersion = Versions[0];
                    var oldVersion = Versions[1];
                    var pType = oldVersion.GetType();

                    var changes = new StringBuilder();

                    foreach (var property in pType.GetProperties())
                    {
                        if (property.Name.ToLower().Equals("modified") || property.Name.ToLower().Equals("modifiedby"))
                            continue;

                        var oldValue = property.GetValue(oldVersion, null);
                        var newValue = property.GetValue(newVersion, null);

                        if (Equals(oldValue, newValue)) continue;

                        var _oldValue = oldValue == null ? "null" : oldValue.ToString();
                        var _newValue = newValue == null ? "null" : newValue.ToString();

                        changes.Append($"<strong>{property.Name}:</strong> {_oldValue} has changed to {_newValue} <br>");
                        changes.AppendLine();
                    }

                    changes.ToString();


                    message.Body = new TextPart("html")
                    {
                        Text = @"Hello " + Cmdb.Custodian + ",\n " +
                        "<br><br>The following record has been updated in CMDB\u207A by " + Cmdb.ModifiedBy + " on " + Cmdb.Modified + ": \n " +
                        "<br><br><a href=" + url + ">" + Cmdb.CdTag + "</a>" +
                        "<br><br>Changes made:" +
                        "<br><br>" + changes 
                    };

                    using (var emailClient = new SmtpClient())
                    {
                        emailClient.Connect("smtp.gmail.com", 465, true);
                        emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                        emailClient.Authenticate("saron.desta@noaa.gov", "oqcakjfsobdjkwji");
                        emailClient.Send(message);
                        emailClient.Disconnect(true);
                    }

                }
                
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
