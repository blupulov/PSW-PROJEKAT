using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.DTOs
{
    public class MakeRecipeDto
    {
        public long ReviewId { get; set; }
        public int DrugQuantity { get; set; }
        public string DrugName { get; set; }

        public MakeRecipeDto() { }
    }
}
