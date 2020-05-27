using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmdbNet.Models
{
    public class Sunflower
    {
        public int SunflowerID { get; set; }
        [Column("Barcode #")]
        [StringLength(50)]
        [DisplayFormat(NullDisplayText = "")]
        public string CdTag { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(255)]
        public string Manufacturer { get; set; }
        [StringLength(255)]
        public string Model { get; set; }
        [Column("Official Name")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("Model Name")]
        [StringLength(255)]
        public string ModelName { get; set; }
        [Column("Serial Number")]
        [StringLength(50)]
        public string SerialNumber { get; set; }
        [Column("Asset Value")]
        public float? AssetValue { get; set; }
        [Column("Effective Date")]
        public DateTime EffectiveDate { get; set; }
        [Column("Cust Area")]
        [StringLength(50)]
        public string CustArea { get; set; }
        [Column("Bureau Or Region")]
        [StringLength(50)]
        public string BureauOrRegion { get; set; }
        [Column("Property Accountability Office")]
        [StringLength(50)]
        public string PropertyAccountabilityOffice { get; set; }
        [Column("Property Contact")]
        [StringLength(50)]
        public string PropertyContact { get; set; }
        [Column("Current User")]
        [StringLength(50)]
        public string CurrentUser { get; set; }
        [Column("Utilization Code")]
        [StringLength(100)]
        public string UtilizationCode { get; set; }
        [Column("Asset Condition")]
        [StringLength(50)]
        public string AssetCondition { get; set; }
        [Column("Condition Description")]
        [StringLength(50)]
        public string ConditionDescription { get; set; }
        [Column("Physical Inventory Date")]
        public DateTime? PhysicalInventoryDate { get; set; }
        [Column("Acquisition Date")]
        public DateTime? AcquisitionDate { get; set; }
        [Column("Responsibility Date")]
        public DateTime? ResponsibilityDate { get; set; }
        [StringLength(50)]
        public string Site { get; set; }
        [StringLength(50)]
        public string Stlv1 { get; set; }
        [StringLength(50)]
        public string Stlv2 { get; set; }
        [Column("Structure Level 3")]
        [StringLength(50)]
        public string Stlv3 { get; set; }
        [Column("Mail Stop")]
        [StringLength(50)]
        public string MailStop { get; set; }
        [Column("Gps 1")]
        [StringLength(50)]
        public string Gps1 { get; set; }
        [Column("Gps 2")]
        [StringLength(50)]
        public string Gps2 { get; set; }
        [Column("Gps 3")]
        [StringLength(50)]
        public string Gps3 { get; set; }
        [Column("Resolution Date")]
        public DateTime? ResolutionDate { get; set; }
        [StringLength(255)]
        public string Resolution { get; set; }
        [Column("Final Event")]
        [StringLength(255)]
        public string FinalEvent { get; set; }
        public DateTime? Datetime { get; set; }
        [Column("Final Event User Defined Field Label 01")]
        [StringLength(255)]
        public string FinalEventUserDefinedFieldLabel01 { get; set; }
        [Column("Final Event User Field 01")]
        [StringLength(255)]
        public string FinalEventUserField01 { get; set; }

        public Cmdb CmdbRecord { get; set; }
        //public Nsd NsdRecord { get; set; }

    }
}
