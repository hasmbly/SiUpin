using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.JenisKomiditis.Commands.CreateJenisKomoditi;
using SiUpin.Shared.JenisKomiditis.Commands.DeleteJenisKomoditi;
using SiUpin.Shared.JenisKomiditis.Commands.UpdateJenisKomoditi;
using SiUpin.Shared.JenisKomiditis.Queries.GetAllJenisKomiditi;
using SiUpin.Shared.JenisKomiditis.Queries.GetJenisKomoditi;
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

        [AllowAnonymous]
        [HttpGet("{jenisKomoditiID}")]
        public async Task<IActionResult> Details(string jenisKomoditiID)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetJenisKomoditiRequest { JenisKomoditiID = jenisKomoditiID }), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateJenisKomoditiRequest request)
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
        [HttpPut]
        public async Task<IActionResult> Update(UpdateJenisKomoditiRequest request)
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
        public async Task<IActionResult> Delete(DeleteJenisKomoditiRequest request)
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