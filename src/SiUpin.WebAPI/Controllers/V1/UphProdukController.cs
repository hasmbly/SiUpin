using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.UphProduks.Command.CreateUphProduk;
using SiUpin.Shared.UphProduks.Queries.GetAllUphProduk;
using SiUpin.Shared.UphProduks.Queries.GetAllUphProdukByUphID;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class UphProdukController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("paginate")]
        public async Task<IActionResult> GetAllUphProduk(GetAllUphProdukRequest request)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(request), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpPost("paginateByUphID")]
        public async Task<IActionResult> GetAllUphProdukByUphID(GetAllUphProdukByUphIDRequest request)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(request), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUphProdukRequest request)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(request), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }
    }
}
