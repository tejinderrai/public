using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShopDataModel
{
    public class Customers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CustomerID { get; set; }

        public int SalutationId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FIRSTNAME { get; set; }
        
        [DataType(DataType.Text)]
        public string MIDDLENAME { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LASTNAME { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public int HOUSENUMBER { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string STREETNAME  { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Area { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CITY { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string POSTCODE { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string TELEPHONE { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CREATEDON { get; set; }
    }
}
