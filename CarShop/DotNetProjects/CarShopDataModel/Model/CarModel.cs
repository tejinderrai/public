using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShopDataModel
{
    public class CarModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CarModelID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Model { get; set; }

        [Required][ForeignKey("ManufacturerId")]
        public Int64 ManufacturerID { get; set; }
    }
}