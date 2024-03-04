﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICarService
    {
        public int GetNumberOfCars();
        public List<Car> GetCarsList();
        public Car CreateCars(Car car);
        public Car GetCarByID(int id);
        public Car UpdateCar(Car updateCar);
        public bool DeleteCar(int carId);
    }
}
