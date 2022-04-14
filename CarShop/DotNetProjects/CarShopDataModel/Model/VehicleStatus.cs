using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopDataModel
{
    public class VehicleStatus
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatuseId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string STATUS { get; set; }
    }
}
