using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopDataModel
{
    public class CarColour
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarColourId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Colour { get; set; }
    }
}
