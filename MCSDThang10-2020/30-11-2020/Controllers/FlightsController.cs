using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlueYonder.Flights.Models;

namespace BlueYonder.Flights.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly FlightsContext _context;

        private readonly ILogger<FlightsController> _logger;

        public FlightsController(ILogger<FlightsController> logger, FlightsContext context)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            //https://mypc/api/flights
            return _context.Flights.ToList();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), flight.Id);
        }
    }
}

/*
 $postParams = "{'origin': 'Germany',
    'destination': 'France',
    'flightNumber': 'GF7625',
    'departureTime': '0001-01-01T00:00:00'}"
Invoke - WebRequest - Uri https://localhost:44335/flights -ContentType "application/json" -Method POST -Body $postParams


 */