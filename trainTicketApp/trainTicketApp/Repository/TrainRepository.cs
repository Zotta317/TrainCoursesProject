﻿using trainTicketApp.Data;
using trainTicketApp.Model;
using static trainTicketApp.Data.TraintDataApi;

namespace trainTicketApp.Repository
{
    public class TrainRepository
    {
        private readonly TrainDbContext trainDbContext;

        public TrainRepository(TrainDbContext context)
        {
            trainDbContext = context;
        }

        public List<Train> GetAllTrains()
        {
            return trainDbContext.Train.ToList();
        }

        public Train GetTrainById(Guid trainId)
        {
            return trainDbContext.Train.FirstOrDefault(train => train.TrainID == trainId);
        }

        public string GetTrainName(Guid trainId)
        {
            var train = trainDbContext.Train.FirstOrDefault(train => train.TrainID == trainId);
            return train?.TrainName;
        }
    }
}
