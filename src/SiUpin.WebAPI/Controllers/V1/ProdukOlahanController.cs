using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.ProdukOlahans.Queries.GetProdukOlahans;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class ProdukOlahanController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<GetProdukOlahansResponse>> Get()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetProdukOlahansRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }
    }
}