using Application.Common.Models;
using Application.Issues.Commands.CreateIssue;
using Application.Issues.Commands.VoteConIssue;
using Application.Issues.Commands.VoteProIssue;
using Application.Issues.Queries.IssueDetail;
using Application.Issues.Queries.IssuesList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/issues")]
    [ApiController]
    public class IssueController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create([FromBody] CreateIssueCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IssueDetailDto>> Get([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new IssueDetailQuery
            {
                Id = id
            }));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseView<IssuesListDto>>> GetAll([FromQuery] IssuesListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPut("vote/pro")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VotePro([FromBody] VoteProIssueCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("vote/con")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VoteCon([FromBody] VoteConIssueCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
