using Entities;
using Model;
using Phramacy_New.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Repositories
{
    public class BeautiesRepositores:BaseRepository<Beauty>,IBeautiesRepositories
    {
        public BeautiesRepositores(PharmacyContext context) :base(context)
        {

        }
        public List<Beauty> getBeauties()
        {
            return _context.Beauties.ToList();
            
        }

       public void delete(int id)
        {
            var b = _context.Beauties.Find(id);
            _context.Remove(b);
            _context.SaveChanges();
        }

        public Beauty Delete(int id)
        {
            var beauty= _context.Beauties.SingleOrDefault(x => x.Id == id);
            return (beauty);
           
        }

        public void Delete(Beauty beauty)
        {
            _context.Beauties.Remove(beauty);
            _context.SaveChanges();
        }

        public Beauty Edit(int id)
        {
            return _context.Beauties.Where(x => x.Id == id).SingleOrDefault();
        }

        public void Edit(Beauty beauty)
        {
            _context.Beauties.Update(beauty);
            _context.SaveChanges();

        }

        public void Create(Beauty beauty)
        {
            _context.Beauties.Add(beauty);
            _context.SaveChanges();
        }
        
       
    }
    
   
}
