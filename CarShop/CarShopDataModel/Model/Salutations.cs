using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShopDataModel
{
    public class Salutations
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalutationId { get; set; }

        public string Name { get; set; }

        public DateTime Registered {get;set;}

    }
}
