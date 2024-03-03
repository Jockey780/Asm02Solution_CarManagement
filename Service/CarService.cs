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

        public int GetNumberOfCars()
        {
            return carRepository.GetNumberOfCars();
        }
    }
}
