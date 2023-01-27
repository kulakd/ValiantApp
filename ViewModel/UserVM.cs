using Microsoft.AspNetCore.Http;

namespace ValiantApp.ViewModel
{
    public class UserVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string? City { get; set; }
        public IFormFile? ProfileImage { get; set; }
    }
}
