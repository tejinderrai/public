using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShopDataModel
{
    public class Vehicles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 VehicleId { get; set; }

        [Required]
        [ForeignKey("ModelId")]
        public Int64 ModelID { get; set; }

        [Required]
        [ForeignKey("ManufacturerId")]
        public Int64 ManufacturerID { get; set; }
        
        [Required]
        [Range(typeof(DateTime), "1/06/2021", "4/10/2021", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [ForeignKey("ColourId")]
        public int ColourId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CREATEDON { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime REGISTRATIONDATE { get; set; }

        [Required(ErrorMessage = "Enter a vehicle identification number")]
        [DataType(DataType.Text)]
        public string VIN { get; set; }

        [Required(ErrorMessage = "Enter a vehicle registration")]
        public string REGISTRATION { get; set; }

        [Required]
        [ForeignKey("FUELTYPEID")]  
        public int FUELTYPEID { get; set; }

        [Required]
        [ForeignKey("STATUSID")]
        public int STATUSID { get; set; }

        [Required]
        public string PreviousOwners { get; set; }

        /// <summary>
        /// Needs more work in the sumission form C_NewVehicle
        /// </summary>
        [Required]
        public int ENGINESIZEID { get; set; }
    }
}
