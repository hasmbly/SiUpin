using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.Kecamatans.Queries.GetKecamatansByKotaID;
using SiUpin.Shared.Kelurahans.Queries.GetKelurahansByKecamatanID;
using SiUpin.Shared.Kotas.Queries.GetKotasByProvinsiID;
using SiUpin.Shared.Provinsis.Queries.GetProvinsis;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class RegionController : BaseController
    {
        [AllowAnonymous]
        [HttpGet("GetProvinsis")]
        public async Task<ActionResult> GetProvinsis()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetProvinsisRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("GetKotasByProvinsiID")]
        public async Task<IActionResult> GetKotasByProvinsiID(string provinsiID)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetKotasByProvinsiIDRequest { ProvinsiID = provinsiID }), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("GetKecamatansByKotaID")]
        public async Task<IActionResult> GetKecamatansByKotaID(string kotaID)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetKecamatansByKotaIDRequest { KotaID = kotaID }), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("GetKelurahansByKecamatanID")]
        public async Task<IActionResult> GetKelurahansByKecamatanID(string kecamatanID)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetKelurahansByKecamatanIDRequest { KecamatanID = kecamatanID }), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }
    }
}