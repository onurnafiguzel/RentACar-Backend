﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }
            //FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count();
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageCarExceded);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\indir.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id).ToList());
        }

    }
}
