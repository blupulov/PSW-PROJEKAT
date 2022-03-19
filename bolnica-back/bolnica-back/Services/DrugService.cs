using bolnica_back.DTOs;
using bolnica_back.GrpcServices;
using bolnica_back.Interfaces;
using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Services
{
    public class DrugService
    {
        private readonly IDrugRepository drugRepository;
        private readonly TestService testService;

        public DrugService(IDrugRepository drugRepository, TestService testService)
        {
            this.drugRepository = drugRepository;
            this.testService = testService;
        }

        public void Test()
        {
            testService.SendMessage();
        }

        public List<Drug> GetAll()
        {
            return (List<Drug>)drugRepository.GetAll();
        }

        public Drug FindById(long id)
        {
            return drugRepository.FindById(id);
        }

        public void Add(MakeDrugDTO dto)
        {
            drugRepository.Add(new Drug(dto));
        }

        public Drug FindDrugByName(string name)
        {
            foreach (Drug d in GetAll())
                if (d.Name.Equals(name))
                    return d;
            return null;
        }
    }
}
