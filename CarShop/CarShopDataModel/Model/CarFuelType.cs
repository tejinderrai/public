using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShopDataModel
{
    public class CarFuelType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FuelTypeId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Fuel { get; set; }
    }
}
