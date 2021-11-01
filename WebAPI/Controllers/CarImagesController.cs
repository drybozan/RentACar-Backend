using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetAllByCarId(int carId)
        {
            var result = _carImageService.GetCarImages(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, [FromForm(Name = "image_path")] IFormFile file)
        {
            var result = _carImageService.Add(carImage, file);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage, [FromForm(Name = "image_path")] IFormFile file)
        {
          
            var result = _carImageService.Update(carImage, file);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
       

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name ="image_id")] int imageId)
        {
            var result = _carImageService.Delete(imageId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
