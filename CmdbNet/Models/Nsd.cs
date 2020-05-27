using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmdbNet.Models
{
    public class Nsd
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NsdID { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [StringLength(50)]
        public string EmailAddress { get; set; }

        public int? SunflowerID { get; set; }
    }
}
