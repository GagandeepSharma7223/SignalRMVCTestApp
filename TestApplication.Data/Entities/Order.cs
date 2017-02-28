using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Data.Entities
{
    public class Order
    {
        public int ID { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string FirstName { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string City { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string State { get; set; }
        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        public string Zip { get; set; }
        [MaxLength(13)]
        [Column(TypeName = "VARCHAR")]
        public string Phone { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }
        public int CardNumber { get; set; }
        public int CardExpirationMonth { get; set; }
        public int CardExpirationYear { get; set; }
        public int CardSecurityCode { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public int ProductId { get; set; }
    }
}
