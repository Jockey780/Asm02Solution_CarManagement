using BusinessObjects.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CarService : ICarService
    {
        private ICarRepository carRepository;
        public CarService()
        {
            carRepository = new CarRepository();
        }

        public Car CreateCars(Car car)
        {
            return carRepository.CreateCars(car);
        }

        public bool DeleteCar(int carId)
        {
            return carRepository.DeleteCar(carId);
        }

        public Car GetCarByID(int id)
        {
            return carRepository.GetCarByID(id);
        }

        public List<Car> GetCarsList()
        {
            return carRepository.GetCarsList();
        }

        public int GetNumberOfCars()
        {
            return carRepository.GetNumberOfCars();
        }

        public Car UpdateCar(Car updateCar)
        {
            return carRepository.UpdateCar(updateCar);
        }
    }
}
