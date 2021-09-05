using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Entities;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>()
            {
                new Car{
                    carId = 1, BrandId = 101, ColorId = 1, DailyPrice = 500, Description = "Düşük segment",
                    ModelYear = 2015 },
                new Car{
                    carId = 2, BrandId = 102, ColorId = 2, DailyPrice = 600, Description = "Düşük segment",
                    ModelYear = 2016 },
                 new Car{
                    carId = 3, BrandId = 103, ColorId = 3, DailyPrice = 700, Description = "Orta segment",
                    ModelYear = 2017 },
                new Car{
                    carId = 4, BrandId = 104, ColorId = 4, DailyPrice = 800, Description = "Yüksek segment",
                    ModelYear = 2018 },
                new Car{
                    carId = 5, BrandId = 105, ColorId = 5, DailyPrice = 900, Description = "Yüksek segment",
                    ModelYear = 2019 }
            };
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.carId == car.carId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public void Delete(Car car)
        {
            Car _carToDelete =_car.SingleOrDefault(c => c.carId == car.carId);
            _car.Remove(_carToDelete);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _car.Where(c => c.carId == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarById(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}