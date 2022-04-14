using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShopDataModel
{
    public class CarManufacturer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ManufacturerID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Manufacturer { get; set; }

    }
}
