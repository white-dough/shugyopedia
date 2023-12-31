﻿using ShugyopediaApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShugyopediaApp.Data.Interfaces
{
    public interface ITrainingCategoryRepository
    {
        IQueryable<TrainingCategory> GetTrainingCategories();
        void AddTrainingCategory(TrainingCategory trainingCategory);
        void EditTrainingCategory(TrainingCategory trainingCategory);
        void DeleteTrainingCategory(TrainingCategory trainingCategory);
    }
}
