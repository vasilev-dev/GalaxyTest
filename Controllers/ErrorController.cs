using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaxyTest.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyTest.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet("exception")]
        public IActionResult Exception()
        {
            throw new Exception("Something went wrong");
        }

        [HttpGet("error")]
        public IActionResult ClientError()
        {
            return new BadRequestObjectResult("Client error!");
        }
    }
}