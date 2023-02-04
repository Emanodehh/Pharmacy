using Entities;
using Model;
using Phramacy_New.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phramacy_New.Repositories
{
    public class FeedbackReporsitory: BaseRepository<Feedback>, IFeedbackRepository
    {

        public FeedbackReporsitory( PharmacyContext context):base(context) //Dependency Injection
        {

        }
         

        public void AddFeedback(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }
    }
}
