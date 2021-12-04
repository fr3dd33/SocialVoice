using Application.Common.Models;
using Application.Organizations.Queries.OrganizationDetail;
using Application.Organizations.Queries.OrganizationsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrganizationController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrganizationDetailDto>> Get([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new OrganizationDetailQuery
            {
                Id = id
            }));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseView<OrganizationsListDto>>> GetAll([FromQuery] OrganizationsListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

    }
}
