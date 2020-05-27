using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmdbNet.Models
{
    public class Ecmo
    {
        public int EcmoID { get; set; }
        [Column("Computer Name")]
        [StringLength(50)]
        public string HostName { get; set; }
        [Column("NOAA Asset Tag")]
        [StringLength(50)]
        public string CdTag { get; set; }
        [Column("IP Address")]
        [StringLength(200)]
        public string IpAddress { get; set; }
        [Column("Last Report Time")]
        [StringLength(100)]
        public string LastReportTime { get; set; }

        public Cmdb CmdbRecord { get; set; }
    }
}
