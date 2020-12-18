using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.Satuans.Queries.GetSatuans;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class SatuanController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<GetSatuansResponse>> Get()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetSatuansRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }
    }
}