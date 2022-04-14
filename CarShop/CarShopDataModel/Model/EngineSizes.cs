using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopDataModel
{
    public class EngineSizes
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EngineSizeId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string EngineSize { get; set; }
    }
}
