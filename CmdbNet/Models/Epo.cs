using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmdbNet.Models
{
    public class Epo
    {
        public int EpoID { get; set; }
        [Column("System Name")]
        [StringLength(50)]
        public string HostName { get; set; }
        [Column("User Name")]
        [StringLength(200)]
        public string Username { get; set; }
        [Column("Last Communication")]
        [StringLength(100)]
        public string LastCommunication { get; set; }

        public Cmdb CmdbRecord { get; set; }
    }
}
