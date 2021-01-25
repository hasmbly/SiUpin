using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.Uphs.Command.CreateUph;
using SiUpin.Shared.Uphs.Command.DeleteUph;
using SiUpin.Shared.Uphs.Command.UpdateUph;
using SiUpin.Shared.Uphs.Queries.GetAllUph;
using SiUpin.Shared.Uphs.Queries.GetCountUphByJenisKomoditi;
using SiUpin.Shared.Uphs.Queries.GetCountUphByJenisTernak;
using SiUpin.Shared.Uphs.Queries.GetCountUphByProvince;
using SiUpin.Shared.Uphs.Queries.GetUph;
using SiUpin.Shared.Uphs.Queries.GetUphAndProduk;
using SiUpin.Shared.Uphs.Queries.GetUphClusterGrades;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class UphController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("paginate")]
        public async Task<IActionResult> GetAllUph(GetAllUphRequest request)
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
        [HttpGet("countByProvince")]
        public async Task<IActionResult> CountByProvince()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetCountUphByProvinceRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("countByJenisKomoditi")]
        public async Task<IActionResult> CountByJenisKomoditi()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetCountUphByJenisKomoditiRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("countByJenisTernak")]
        public async Task<IActionResult> CountByJenisTernak()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetCountUphByJenisTernakRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("uphIDandNames")]
        public async Task<IActionResult> GetUphIDandNames()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetUphIDandNamesRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("details/{uphID}")]
        public async Task<IActionResult> Details(string uphID)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetUphAndProdukRequest { UphID = uphID }), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpGet("{uphID}")]
        public async Task<IActionResult> GetUph(string uphID)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetUphRequest { UphID = uphID }), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUphRequest request)
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
        [HttpGet("cluster/grade")]
        public async Task<IActionResult> UphClusterGrades()
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetUphClusterGradesRequest()), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUphRequest request)
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
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(DeleteUphRequest request)
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