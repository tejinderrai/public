using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarShopDataModel
{
    public class Vehicles_View
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 VehicleId { get; set; }

        [DataType(DataType.Text)]
        public string Manufacturer { get; set; }

        [DataType(DataType.Text)]
        public string Model { get; set; }

        [DataType(DataType.Text)]
        public string Colour { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime REGISTRATIONDATE { get; set; }

        public string REGISTRATION { get; set; }

        [DataType(DataType.Text)]
        public string Fuel { get; set; }

        [DataType(DataType.Text)]
        public string STATUS { get; set; }

        public int PreviousOwners { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
