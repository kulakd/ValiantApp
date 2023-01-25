using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ValiantApp.Data;

namespace ValiantApp.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public string? ProfileImage { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public Category Category { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }


    }
}
