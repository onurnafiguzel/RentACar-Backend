using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars

                             join b in context.Brands
                                 on c.BrandId equals b.BrandId

                             join co in context.Colors
                                 on c.ColorId equals co.ColorId

                             select new CarDetailDto
                             {
                                 CarId = c.carId,
                                 BrandId = b.BrandId,
                                 BrandName = b.Name,
                                 ColorId = co.ColorId,
                                 CarName = c.Description,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 FindeksScore=c.FindeksScore
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public CarDetailDto GetCarById(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars

                             join b in context.Brands
                                 on c.BrandId equals b.BrandId

                             join co in context.Colors
                                 on c.ColorId equals co.ColorId

                             select new CarDetailDto
                             {
                                 CarId = c.carId,
                                 BrandId = b.BrandId,
                                 BrandName = b.Name,
                                 ColorId = co.ColorId,
                                 CarName = c.Description,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 FindeksScore=c.FindeksScore
                             };
                return filter == null ? result.SingleOrDefault() : result.Where(filter).SingleOrDefault();
            }
        }


    }
}