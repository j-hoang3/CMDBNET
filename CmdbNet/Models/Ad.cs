using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmdbNet.Models
{
    public class Ad
    {
        public int AdID { get; set; }
        [Column("Computer Name")]
        [StringLength(50)]
        public string HostName { get; set; }
        public DateTime? Created { get; set; }
        [Column("Account Disabled")]
        public bool? AccountDisabled { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        public Cmdb CmdbRecord { get; set; }
    }
}
