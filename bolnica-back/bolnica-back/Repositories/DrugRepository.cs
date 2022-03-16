using bolnica_back.Interfaces;
using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Repositories
{
    public class DrugRepository : Repository<Drug>, IDrugRepository
    {
        public DrugRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public void UpdateQuantity(int count, long id)
        {
            Drug drug = FindById(id);
            drug.Quantity += count;
            ApplicationDbContext.SaveChanges();
        }

    }
}
