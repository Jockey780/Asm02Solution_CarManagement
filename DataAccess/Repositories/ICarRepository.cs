﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface ICarRepository
    {
        public int GetNumberOfCars();
        public List<Car> GetCarsList();
    }
}
