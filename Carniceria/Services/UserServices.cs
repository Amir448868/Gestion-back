using Carniceria.Data;
using Carniceria.Data.Models.Dto;
using Carniceria.Entities;

namespace Carniceria.Services
{
    public class UserServices
    {
        private readonly CarniceriaContext _context;

        public UserServices(CarniceriaContext context)
        {
            _context = context;
        }

        public User ValidateUser(AuthenticationRequest user)
        {
            return _context.Users.FirstOrDefault(x => x.username == user.username && x.password == user.password);
        }
    }
}
