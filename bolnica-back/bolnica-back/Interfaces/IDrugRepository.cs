using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Interfaces
{
    public interface IDrugRepository : IRepository<Drug>
    {
        void UpdateQuantity(int count, long id);
    }
}
