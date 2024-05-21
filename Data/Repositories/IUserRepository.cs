
using WebFood_2.Models;

namespace WebFood_2.Data.Repositories
{
   public interface IUserRepository
   {
       bool IsEmailExist(string email);
       void AddUser(Users user);
        Users GetUsersLogin(string email,string password);
   }

    public class UserRepository : IUserRepository
    {
        private WebFoodContext _context;

        public UserRepository(WebFoodContext context)
        {
            _context = context;
        }

        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(u => u.UserEmail == email);
        }

        public void AddUser(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        
        public Users GetUsersLogin(string email, string password)
        {
            return _context.Users.SingleOrDefault(x=>x.UserEmail == email && x.Password==password);
        }
    }

}
