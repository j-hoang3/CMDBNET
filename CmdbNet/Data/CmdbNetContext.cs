using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CmdbNet.Models
{
    public class CmdbNetContext : DbContext
    {
        public CmdbNetContext (DbContextOptions<CmdbNetContext> options)
            : base(options)
        {
        }

        public DbSet<CmdbNet.Models.Cmdb> Cmdb { get; set; }
        public DbSet<CmdbNet.Models.Ad> Ad { get; set; }
        public DbSet<CmdbNet.Models.Ecmo> Ecmo { get; set; }
        public DbSet<CmdbNet.Models.Epo> Epo { get; set; }
        //public DbSet<CmdbNet.Models.Nsd> Nsd { get; set; }
        public DbSet<CmdbNet.Models.Sccm> Sccm { get; set; }
        public DbSet<CmdbNet.Models.Sunflower> Sunflower { get; set; }

    }

}
