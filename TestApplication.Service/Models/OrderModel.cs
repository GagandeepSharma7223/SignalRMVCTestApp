using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApplication.Service.Models
{
    public class OrderModel
    {
        public int ID { get; set; }
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [MaxLength(10)]
        public string Zip { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(13, MinimumLength = 10)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Phone { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required, Display(Name = "Card Number")]
        public int CardNumber { get; set; }
        [Required, Display(Name = "Card Expiration Month")]
        public int CardExpirationMonth { get; set; }
        [Required, Display(Name = "Card Expiration Year")]
        public int CardExpirationYear { get; set; }
        [Required, Display(Name = "Card Security Code")]
        public int CardSecurityCode { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public int ProductId { get; set; }
    }
}