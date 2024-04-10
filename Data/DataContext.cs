using DemoAutorization.Models;

namespace DemoAutorization.Data
{
    public static class DataContext
    {
        public static List<User> Users { get; set; } = new List<User>()
        {
            new User("login","password","email","name"){ Id = 0},
            new User("1","1","email-1","name-1"){ Id = 1}
        };
    }
}
