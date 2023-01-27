using System.ComponentModel.DataAnnotations;

namespace ValiantApp.ViewModel
{
    public class HomeUserCreateVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
