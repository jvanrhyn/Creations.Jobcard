using Jobcard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobcard.Web.Controllers
{
    [Route("api/[controller]")]
    public class LayerKindController : ControllerBase
    {
        private readonly ILogger<LayerKindController> _logger;

        public LayerKindController(ILogger<LayerKindController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<LayerKindDefault>> GetAll()
        {
            _logger.LogInformation("Getting all Layerkind defaults");
            var result = new List<LayerKindDefault>
            {
                new LayerKindDefault
                {
                    Acceleration = 100,
                    Blower = true,
                    Corner = 100,
                    LayerType = LayerType.Cut,
                    Name = "3mm MDF Cut",
                    Power1 = 50,
                    Power1Min = 50,
                    Power2 = 50,
                    Power2Min = 50,
                    ScanGap = 0.065m,
                    Speed = 100

                },
                new LayerKindDefault
                {
                    Acceleration = 100,
                    Blower = true,
                    Corner = 100,
                    LayerType = LayerType.Cut,
                    Name = "6mm MDF Cut",
                    Power1 = 50,
                    Power1Min = 50,
                    Power2 = 50,
                    Power2Min = 50,
                    ScanGap = 0.065m,
                    Speed = 100

                }
            };

            return Ok(result);
        }
    }
}
