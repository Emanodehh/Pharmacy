using Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Repositories
{
    public class BaseRepository<T> where T:BaseEntity  //genaric      
    {
        protected readonly PharmacyContext _context;
        public BaseRepository(PharmacyContext context) 

        { 
            _context = context;

        }


        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        
    }
}
