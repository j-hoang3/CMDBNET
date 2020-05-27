using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmdbNet.Models
{
    public class Sccm
    {
        public int SccmID { get; set; }
        [Column("Computer Name")]
        [StringLength(50)]
        public string HostName { get; set; }
        [Column("Top Console User")]
        [StringLength(50)]
        public string TopConsoleUser { get; set; }
        [Column("Operating System")]
        [StringLength(100)]
        public string OperatingSystem { get; set; }

        public Cmdb CmdbRecord { get; set; }
    }
}
