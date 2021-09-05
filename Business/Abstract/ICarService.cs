using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDetailDto> GetCarById(int id);
        IDataResult<List<CarDetailDto>> GetCarsByBrandIdAndColorId(int brandId, int colorId);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult Add(Car car);
        IResult AddTransactionalTest(Car car);
        decimal CalculateFindeksScore(int carId);
    }
}