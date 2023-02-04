using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Interfaces
{
   public interface IBeautiesRepositories
    {

        Beauty GetById(int id);

        List<Beauty> getBeauties();
        Beauty Delete(int id);
        void Delete(Beauty beauty);
        Beauty Edit(int id);
        void Edit(Beauty beauty);
        void Create(Beauty beauty);
        
    }
}
