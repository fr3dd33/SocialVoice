using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace WebUI.Controllers
{
    public class BaseController : ControllerBase
    {
        private IMediator mediator;
        private ILogger<BaseController> logger;

        protected IMediator Mediator
        {
            get
            {
                if (mediator == null)
                    mediator = HttpContext.RequestServices.GetService<IMediator>();
                return mediator;
            }
        }
    }
}
