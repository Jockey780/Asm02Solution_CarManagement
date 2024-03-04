using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CarDAO
    {
        private static CarDAO instance = null;
        private readonly CarManagementContext dbContext = null;

        private CarDAO()
        {
            dbContext = new CarManagementContext();
        }
        public static CarDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CarDAO();
                }
                return instance;
            }
        }

        public int GetNumberOfCars()
        {
            int NumberOfCars = 0;
            try
            {
                var dbContext = new CarManagementContext();
                NumberOfCars = dbContext.Cars.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NumberOfCars;
        }

        public List<Car> GetCarsList()
        {
            List<Car> list = null;
            try
            {
                var dbContext = new CarManagementContext();
                list = dbContext.Cars.Include(c=>c.Category).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public Car CreateCars(Car car)
        {
            try
            {
                if (car != null)
                {
                    var dbContext = new CarManagementContext();
                    dbContext.Cars.Add(car);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }
    }
}
