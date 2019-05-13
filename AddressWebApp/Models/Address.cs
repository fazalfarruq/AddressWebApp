using System.ComponentModel.DataAnnotations.Schema;

namespace AddressWebApp.Models
{
    [Table("Address")]
    public class Address
    {
        public string Id { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
    }
}