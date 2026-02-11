using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator? Mediator;
        protected IMediator _mediator => Mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
