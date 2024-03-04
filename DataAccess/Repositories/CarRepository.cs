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
        public Car GetCarByID(int id)=>CarDAO.Instance.GetCarByID(id);
        public Car UpdateCar(Car updateCar)=>CarDAO.Instance.UpdateCar(updateCar);
        public bool DeleteCar(int carId) =>  CarDAO.Instance.DeleteCar(carId);
    }
}
