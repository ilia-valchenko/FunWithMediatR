using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FunWithMediatR.Api.Controllers
{
    public class HealthCheckController : BaseController
    {
        public HealthCheckController(IMediator mediator) : base(mediator)
        {
        }

        public IActionResult HealthCheck()
        {
            return Ok();
        }
    }
}