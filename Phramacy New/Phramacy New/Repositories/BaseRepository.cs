using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Repositories
{
    public class BaseRepository
    {
        protected readonly PharmacyContext _context;

        public BaseRepository(PharmacyContext context)
        {
            _context = context;
        }
    }
}
