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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental,bool>> filter=null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals

                             join c in context.Cars
                             on r.CarId equals c.carId

                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             join cs in context.Customers
                             on r.CustomerId equals cs.UserId

                             join u in context.Users
                             on cs.UserId equals u.Id

                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = c.carId,
                                 CarDescription = c.Description,
                                 BrandName = b.Name,
                                 UserName = cs.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }

        public RentalDetailDto GetRentalDetail(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals.Where(r => r.CarId == id)

                             join c in context.Cars
                             on r.CarId equals c.carId

                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             join cs in context.Customers
                             on r.CustomerId equals cs.UserId

                             join u in context.Users
                             on cs.UserId equals u.Id

                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = c.carId,
                                 CarDescription = c.Description,
                                 BrandName = b.Name,
                                 UserName = cs.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
