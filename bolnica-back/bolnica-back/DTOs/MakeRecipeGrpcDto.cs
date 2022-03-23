using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.DTOs
{
    public class MakeRecipeGrpcDto
    {
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public string Jmbg { get; set; }
    }
}
