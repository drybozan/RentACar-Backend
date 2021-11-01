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
    public class RentalsController : ControllerBase
    {
         IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyrentalid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetRentalById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _rentalService.GetByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _rentalService.GetByCustomerId(customerId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getcanberented")]
        public IActionResult GetCanBeRented()
        {
            var result = _rentalService.GetCanBeRented();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getdetails")]
        public IActionResult GetDetails()
        {
            var result = _rentalService.GetRentalsDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
