using bolnica_back.Interfaces;
using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Services
{
    public class PenaltyPointService
    {
        private readonly IPenaltyPointRepository penaltyPointRepository;

        public PenaltyPointService(IPenaltyPointRepository penaltyPointRepository)
        {
            this.penaltyPointRepository = penaltyPointRepository;
        }

        public List<PenaltyPoint> GetAll()
        {
            return (List<PenaltyPoint>)penaltyPointRepository.GetAll();
        }

        public void AddPenaltyPointToUser(long id)
        {
            penaltyPointRepository.Add(new PenaltyPoint(id));
        }

        public PenaltyPoint FindById(long id)
        {
            return penaltyPointRepository.FindById(id);
        }

        public void ClearAllPenaltyPointsOfUser(long userId)
        {
            List<PenaltyPoint> penaltyPoints = FindAllNotDeletedPenaltyPointsOfUser(userId);
            penaltyPointRepository.LogicalDeleting(GetAllIdsOfPenaltyPointList(penaltyPoints));
        }
        
        public int GetNumberOfUserPenaltyPointsInLastMonth(long userId)
        {
            int number = 0;
            DateTime compareTime = DateTime.Now.AddDays(-30);
            foreach(PenaltyPoint pp in FindAllNotDeletedPenaltyPointsOfUser(userId))
            {
                if (compareTime <= pp.WhenRecived)
                    number += 1;
            }
            return number;
        }

        private List<long> GetAllIdsOfPenaltyPointList(List<PenaltyPoint> penaltyPoints)
        {
            List<long> ids = new List<long>();
            foreach(PenaltyPoint pp in penaltyPoints)
            {
                ids.Add(pp.Id);
            }
            return ids;
        }

        private List<PenaltyPoint> FindAllNotDeletedPenaltyPointsOfUser(long userId)
        {
            List<PenaltyPoint> penaltyPoints = new List<PenaltyPoint>();
            foreach(PenaltyPoint pp in GetAll())
            {
                if(!pp.IsDeleted && pp.UserId == userId)
                    penaltyPoints.Add(pp);
            }
            return penaltyPoints;
        }
    }
}
