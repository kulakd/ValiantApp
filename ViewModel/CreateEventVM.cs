using ValiantApp.Data;
using ValiantApp.Models;

namespace ValiantApp.ViewModel
{
    public class CreateEventVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public EventCategory eventCategory { get; set; }
        public string UserId { get; set; }
    }
}
