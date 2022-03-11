using bolnica_back.Interfaces;
using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Repositories
{
    public class PenaltyPointRepository : Repository<PenaltyPoint>, IPenaltyPointRepository
    {
        public PenaltyPointRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
        //AKO NE RADI VRATITI PRVOBITNO
        public void LogicalDeleting(List<long> ids)
        {
            foreach(long id in ids)
            {
                PenaltyPoint pp = FindById(id);
                pp.IsDeleted = true;
            }
            ApplicationDbContext.SaveChanges();
        }
    }
}
