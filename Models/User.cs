using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValiantApp.Models
{
    public class User : IdentityUser
    {
        public string? ProfileImage { get; set; }
        public string? City { get; set; }
        
        [ForeignKey("Address")]
        public int AddressIP { get; set; }
        public Address? Address { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
