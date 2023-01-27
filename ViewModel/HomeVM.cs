using ValiantApp.Models;

namespace ValiantApp.ViewModel
{
    public class HomeVM
    { 
        public IEnumerable<Club>? Clubs { get; set; }
        public string? City { get; set; }
        public HomeUserCreateVM Register { get; set; } = new HomeUserCreateVM();

    }
}
