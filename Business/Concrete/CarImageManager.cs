using Business.Abstract;
using Business.Constanst;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
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
             ICarImageDal _carImageDal;

            public CarImageManager(ICarImageDal carImageDal)
            {
                _carImageDal = carImageDal;
            }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarsImagesListed);
            }

            public IDataResult<List<CarImage>> GetCarImages(int carId)
            {
                var checkIfCarImage = CheckIfCarImage(carId);
                var images = checkIfCarImage.Success
                    ? checkIfCarImage.Data
                    : _carImageDal.GetAll(c => c.car_id == carId);
                return new SuccessDataResult<List<CarImage>>(images, Messages.CarImagesListed);
            }

        [CacheAspect]
        public IDataResult<CarImage> GetById(int imageId)
            {
                return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.image_id == imageId), Messages.CarImageListed);
            }

        [ValidationAspect(typeof(CarImageValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImage carImage, IFormFile file)
            {
                IResult rulesResult = BusinessRules.Run(CheckIfCarImageLimit(carImage.car_id));
                if (rulesResult != null)
                {
                    return rulesResult;
                }

                var imageResult = FileHelper.Upload(file);
                if (!imageResult.Success)
                {
                    return new ErrorResult(imageResult.Message);
                }
                carImage.image_path = imageResult.Message;
                carImage.date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.CarImageAdded);
            }

        [ValidationAspect(typeof(CarImageValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(CarImage carImage, IFormFile file)
            {
                IResult rulesResult = BusinessRules.Run(CheckIfCarImageLimit(carImage.car_id));
                if (rulesResult != null)
                {
                    return rulesResult;
                }

                var image = _carImageDal.Get(c => c.image_id == carImage.image_id);
                if (image == null)
                {
                    return new ErrorResult(Messages.ImageNotFound);
                }
                var result = FileHelper.Update(file, image.image_path);
                if (!result.Success)
                {
                    return new ErrorResult(Messages.ErrorUpdatingImage);
                }
                carImage.image_path = result.Message;
                carImage.date = DateTime.Now;
                _carImageDal.Update(carImage);
                return new SuccessResult(Messages.CarImageUpdated);
            }

        [ValidationAspect(typeof(CarImageValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(int imageId)
            {
                var image = _carImageDal.Get(c => c.image_id == imageId);
                if (image == null)
                {
                    return new ErrorResult(Messages.ImageNotFound);
                }
                var result = FileHelper.Delete(image.image_path);
                if (!result.Success)
                {
                    return new ErrorResult(Messages.ErrorDeletingImage);
                }
                _carImageDal.Delete(image);
                return new SuccessResult(Messages.CarImageDeleted);
            }

            private IResult CheckIfCarImageLimit(int carId)
            {
                int result = _carImageDal.GetAll(c => c.car_id == carId).Count;
                if (result >= 5)
                {
                    return new ErrorResult(Messages.CarImageLimitExceeded);
                }
                return new SuccessResult();
            }

            private IDataResult<List<CarImage>> CheckIfCarImage(int carId)
            {
                string logoPath = "/Uploads/images/default.jpg";
                bool result = _carImageDal.GetAll(c => c.car_id == carId).Any();
                if (!result)
                {
                    List<CarImage> imageList = new List<CarImage>();
                    imageList.Add(new CarImage
                    {
                        image_path = logoPath,
                        car_id = carId,
                        date = DateTime.Now
                    });
                    return new SuccessDataResult<List<CarImage>>(imageList);
                }
                return new ErrorDataResult<List<CarImage>>(new List<CarImage>());
            }
        }
    }

