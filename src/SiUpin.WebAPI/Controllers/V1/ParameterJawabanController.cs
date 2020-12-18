using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.ParameterJawabans.Queries.GetParameterJawabansByIndikatorName;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class ParameterJawabanController : BaseController
    {
        [AllowAnonymous]
        [HttpGet("byIndikatorName")]
        public async Task<IActionResult> GetByName(string indikatorName)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetParameterJawabansByIndikatorNameRequest { ParameterIndikatorName = indikatorName }), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }
    }
}