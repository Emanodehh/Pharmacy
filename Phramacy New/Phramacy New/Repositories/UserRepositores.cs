using Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Repositories
{
    public class UserRepositores : BaseRepository,IUserRepository
    {
        public UserRepositores(PharmacyContext context) : base(context)
        {
        }
        public User Login(User user)
        {
            return _context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).ToList().FirstOrDefault();

        }
    }

    public interface IUserRepository
    {
        User Login(User user);
    }
}
