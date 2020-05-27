using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmdbNet.Models
{
    public class Cmdb
    {
        public int CmdbID { get; set; }
        [Required]
        [StringLength(50)]
        public string CdTag { get; set; }
        [StringLength(50)]
        public string Organization { get; set; }
        [StringLength(50)]
        public string HostName { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
        [StringLength(50)]
        public string Floor { get; set; }
        [StringLength(50)]
        public string Room { get; set; }
        [StringLength(50)]
        public string IpAddress { get; set; }
        public int? SubnetMask { get; set; }
        [StringLength(50)]
        public string MacAddress { get; set; }
        [StringLength(100)]
        public string Manufacturer { get; set; }
        [StringLength(100)]
        public string Model { get; set; }
        [StringLength(100)]
        public string SerialNumber { get; set; }
        [StringLength(50)]
        public string OperatingSystem { get; set; }
        [StringLength(100)]
        public string AdUser { get; set; }
        [StringLength(100)]
        public string SunflowerUser { get; set; }
        [StringLength(100)]
        public string Status { get; set; }
        [StringLength(50)]
        public string ClassType { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        [StringLength(50)]
        public string Custodian { get; set; }
        [StringLength(500)]
        public string Comments { get; set; }
        [StringLength(50)]
        public string InventoriedBy { get; set; }
        public DateTime? InventoryDate { get; set; }
        public DateTime? LastScan { get; set; }
        [StringLength(50)]
        public string ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }

        public int? AdID { get; set; }
        public int? EcmoID { get; set; }
        public int? EpoID { get; set; }
        public int? SccmID { get; set; }
        public int? SunflowerID { get; set; }

        public Ad AdRecord { get; set; }
        public Ecmo EcmoRecord { get; set; }
        public Epo EpoRecord { get; set; }
        public Sccm SccmRecord { get; set; }
        public Sunflower SunflowerRecord { get; set; }
    }
}
