﻿using Basecode.Data.Repositories;
using ShugyopediaApp.Data.Interfaces;
using ShugyopediaApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShugyopediaApp.Data.Repositories
{
    public class RatingRepository : BaseRepository, IRatingRepository
    {
        public RatingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public IQueryable<Rating> GetRatings()
        {
            return this.GetDbSet<Rating>();
        }
    }
}