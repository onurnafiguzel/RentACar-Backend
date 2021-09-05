using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;
        private ICarService _carService;
        private IRentalService _rentalService;

        public CreditCardManager(ICreditCardDal creditCardDal, ICarService carService, IRentalService rentalService)
        {
            _creditCardDal = creditCardDal;
            _carService = carService;
            _rentalService = rentalService;
        }

        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult();
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        public IDataResult<List<CreditCard>> Getall()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<List<CreditCard>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IDataResult<List<CreditCard>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<bool> Pay(PayDto pay)
        {
            if (_rentalService.IsRentCheck(new Rental { CarId = pay.CarId, RentDate = pay.RentDate, ReturnDate = pay.ReturnDate }))
            {
                var car = _carService.GetCarById(pay.CarId);
                var day = pay.ReturnDate - pay.RentDate;
                var totlDays = day.TotalDays == 0 ? 1 : day.TotalDays;
                if (((decimal)totlDays * car.Data.DailyPrice) != pay.AmountPay)
                {
                    return new SuccessDataResult<bool>(false);
                }
                Add(new CreditCard { CardNumber = pay.CardNumber, CVV = pay.CVV, ExpirationDate = pay.ExpirationDate, NameOnTheCard = pay.NameOnTheCard });
                return new SuccessDataResult<bool>(true);
            }
            return new SuccessDataResult<bool>(false);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }
    }
}
