using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.JenisTernaks.Queries.GetJenisTernaks;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class JenisTernakController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<GetJenisTernaksResponse>> Get()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetJenisTernaksRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }
    }
}