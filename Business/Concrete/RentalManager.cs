using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        private readonly ICarService _carService;
        private readonly ICustomerService _customerService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            if (FindeksCheck(rental))
            {
                if (IsRentCheck(rental))
                {
                    _rentalDal.Add(rental);
                    _customerService.AddFindeksScore(rental.CustomerId, rental.CarId);
                    return new SuccessResult(Messages.RentalAdded);
                }
                else
                {
                    return new ErrorResult(Messages.RentalAddedError);
                }
            }
            else
            {
                return new ErrorResult(Messages.FindeksScoreError);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetByRentalId(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsById(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CarId == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public bool IsRentCheck(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && (r.RentDate.Date == rental.RentDate.Date || r.ReturnDate.Date >= rental.RentDate));
            if (result.Count > 0)
            {
                return false;
            }
            return true;
        }

        public bool FindeksCheck(Rental rental)
        {
            var car = _carService.GetCarById(rental.CarId);
            var customer = _customerService.GetById(rental.CustomerId);
            if (car.Data.FindeksScore <= customer.Data.FindeksScore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
