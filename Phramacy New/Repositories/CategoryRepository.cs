using Entities;
using Model;
using Phramacy_New.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Repositories
{
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepositories
    {
        public CategoryRepository(PharmacyContext context):base(context)
        { 
        }

        public List<Category> getallcategory()
        {
            return _context.Categories.ToList();
        }
    }
}
