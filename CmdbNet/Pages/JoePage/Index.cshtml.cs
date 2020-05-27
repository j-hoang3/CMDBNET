using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CmdbNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CmdbNet.Pages.JoePage
{
	public class IndexModel : PageModel
	{
		private readonly CmdbNet.Models.CmdbNetContext _context;

		public IndexModel(CmdbNet.Models.CmdbNetContext context)
		{
			_context = context;
		}

		public IList<Cmdb> Cmdb { get; set; }

		/*public async Task<JsonResult> OneGetListAsync()
        {
			Cmdb = await _context.Cmdb
				.Include(c => c.Cmdb)
				.Where(i => i.Floor == 5)
				.AsNoTracking()
				.ToListAsync();

			return new JsonResult(Cmdb);
        }*/

	}

}
