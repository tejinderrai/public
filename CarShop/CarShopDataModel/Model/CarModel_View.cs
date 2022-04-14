using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShopDataModel
{
    public class CarModel_View
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Int64 CarModelID { get; set; }

        [DataType(DataType.Text)]
        public string Model { get; set; }

        [DataType(DataType.Text)]
        public string Manufacturer { get; set; }

    }
}