using System.Diagnostics.Tracing;
using ValiantApp.Data;
using ValiantApp.Models;

namespace ValiantApp.ViewModel
{
    public class EditEventVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public IFormFile? Image { get; set; }
        public string? URL { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public EventCategory eventCategory { get; set; }
    }
}
