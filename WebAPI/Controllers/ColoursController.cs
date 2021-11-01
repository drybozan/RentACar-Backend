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
    public class ColoursController : ControllerBase
    {

        IColourService _colourService;

        public ColoursController(IColourService colourService)
        {
            _colourService = colourService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colourService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _colourService.GetById(id);
            if (result.Success)
            {
                return Ok(result); //datayı gösterir
            }

            return BadRequest(result.Message); //400 geldiğinde errordataresult görecek
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string colorName)
        {
            var result = _colourService.GetByName(colorName);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        public IActionResult Add(Colour colour)
        {
            var result = _colourService.Add(colour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Colour colour)
        {
            var result = _colourService.Delete(colour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Colour colour)
        {
            var result = _colourService.Update(colour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
