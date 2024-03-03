using BusinessObjects.Models;
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
    }
}
