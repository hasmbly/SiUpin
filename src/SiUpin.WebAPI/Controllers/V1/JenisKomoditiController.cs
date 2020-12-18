using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.JenisKomiditis.Queries.GetAllJenisKomiditi;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class JenisKomoditiController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<GetAllJenisKomiditiResponse>> Get()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetAllJenisKomiditiRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }
    }
}