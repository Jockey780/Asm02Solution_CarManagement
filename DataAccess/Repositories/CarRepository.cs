using BusinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CarRepository : ICarRepository
    {
        public int GetNumberOfCars() => CarDAO.Instance.GetNumberOfCars();
        public List<Car> GetCarsList() => CarDAO.Instance.GetCarsList();
        public Car CreateCars(Car car)=> CarDAO.Instance.CreateCars(car);
    }
}
