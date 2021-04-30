using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hasin.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PhoneBookController> _logger;

        public PhoneBookController(ILogger<PhoneBookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PhoneBookRecord> Get()
        {
        }
    }
}
