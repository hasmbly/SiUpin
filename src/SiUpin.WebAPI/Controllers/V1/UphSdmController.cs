﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.GetUphSdms.Queries;
using SiUpin.Shared.UphSdms.Commands;
using SiUpin.Shared.UphSdms.Queries;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class UphSdmController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("paginate")]
        public async Task<IActionResult> Paginate(GetUphSdmsRequest request)
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
        [HttpGet("{uphSdmID}")]
        public async Task<IActionResult> Details(string uphSdmID)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(new GetUphSdmRequest { UphSdmID = uphSdmID }), "Successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUphSdmRequest request)
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
        public async Task<IActionResult> Update(UpdateUphSdmRequest request)
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
        public async Task<IActionResult> Delete(DeleteUphSdmRequest request)
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
