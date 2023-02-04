using Entities;
using Model;
using Phramacy_New.Constants;
using Phramacy_New.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Repositories
{
    public class UserRepositores : BaseRepository<User>,IUserRepository 
    {
        public UserRepositores(PharmacyContext context) : base(context)
        {

        }
        public User Login(User user)
        {
            return _context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).ToList().FirstOrDefault();

        }


        public void Register(User user)
        {
            user.Role = SesstionTitle.client;
            _context.Users.Add(user);
            _context.SaveChanges();
            
           

        }
    }

   
}
