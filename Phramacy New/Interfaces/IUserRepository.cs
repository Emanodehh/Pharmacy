using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Interfaces
{
    public interface IUserRepository
    {
        User Login(User user);
        void Register(User user);

    }
}
