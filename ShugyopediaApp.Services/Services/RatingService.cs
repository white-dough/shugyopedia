﻿using ShugyopediaApp.Data.Interfaces;
using ShugyopediaApp.Data.Models;
using ShugyopediaApp.Data.Repositories;
using ShugyopediaApp.Services.Interfaces;
using ShugyopediaApp.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShugyopediaApp.Services.Services
{
    public class RatingService: IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public float GetRatingAverageFromTraining(int trainingId)
        {
            var data = _ratingRepository.GetRatings().Where(s => s.TrainingId == trainingId).Select(s => new RatingViewModel { Rate = s.Rate});
            var sumOfRates = data.Select(s => (float)s.Rate).Sum();
            var countOfRatings = data.Count();
            float averageRate = countOfRatings > 0 ? sumOfRates / countOfRatings : 0;
            averageRate = (float)Math.Round(averageRate, 1);
            return averageRate;
        }

        public void DeleteRating(int ratingId) 
        {
            var model = new Rating();
            model.RatingId = ratingId;
            _ratingRepository.DeleteRating(model);
        }
    }
}
