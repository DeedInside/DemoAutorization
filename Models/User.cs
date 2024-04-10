using System.ComponentModel.DataAnnotations;

namespace DemoAutorization.Models
{
    public class User
    {
        public User( string login, string password, string email, string name)
        {
            Login = login;
            Password = password;
            Email = email;
            Name = name;
        }
        public User() { }

        public int Id { get; set; } = 0;

        [Required(ErrorMessage ="Введите логин")]
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
