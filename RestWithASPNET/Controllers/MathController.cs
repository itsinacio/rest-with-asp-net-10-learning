using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Model;
using System;
using RestWithASPNET.Utils;
using RestWithASPNET.Services;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathController : ControllerBase
    {

        public readonly MathService _service;

        public MathController(MathService service)
        {
            _service = service;
        }


        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (NumberHelper.isNumeric(firstNumber) && NumberHelper.isNumeric(secondNumber))
            {
                var sum = _service.Sum(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok("sum is " + sum);
            }
            return BadRequest("Invalid Input!");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtration(string firstNumber, string secondNumber)
        {
            if (NumberHelper.isNumeric(firstNumber) && NumberHelper.isNumeric(secondNumber))
            {
                var sub = _service.Subtration(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok("subtraction is " + sub);
            }
            return BadRequest("Invalid Input!");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (NumberHelper.isNumeric(firstNumber) && NumberHelper.isNumeric(secondNumber))
            {
                var multi = _service.Multiplication(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok("multiplication is " + multi);
            }
            return BadRequest("Invalid Input!");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (NumberHelper.isNumeric(firstNumber) && NumberHelper.isNumeric(secondNumber))
            {
                var div = _service.Division(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok("division is " + div);
            }
            return BadRequest("Invalid Input!");
        }

        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {
            if (NumberHelper.isNumeric(firstNumber) && NumberHelper.isNumeric(secondNumber))
            {
                var ave = _service.Average(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok("average is " + ave);
            }
            return BadRequest("Invalid Input!");
        }

        [HttpGet("squareRoot/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (NumberHelper.isNumeric(firstNumber))
            {
                var Sqr = _service.SquareRoot(NumberHelper.ConvertToDecimal(firstNumber));
                return Ok("squareRoot is " + Sqr);
            }
            return BadRequest("Invalid Input!");
        }
    }
}
