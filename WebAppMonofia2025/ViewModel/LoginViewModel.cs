using System.ComponentModel.DataAnnotations;

namespace WebAppMonofia2025.ViewModel
{
    public class LoginViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public bool RememeberMe { get; set; }
    }
}
