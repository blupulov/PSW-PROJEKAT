using bolnica_back.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Model
{
    public class Drug
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public Drug() { }

        public Drug(MakeDrugDTO dto)
        {
            Name = dto.Name;
            Description = dto.Description;
            Quantity = 0;
        }

        public Drug(long id, string name, int quantity, string description)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Description = description;
        }
    }
}
