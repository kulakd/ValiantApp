using ValiantApp.Models;
using ValiantApp.Data;

namespace ValiantApp.ViewModel
{
    public class CreateClubVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public Category Category { get; set; }
    }
}
