﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.UphPasars.Queries;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class UphPasarController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("paginate")]
        public async Task<IActionResult> Paginate(GetUphPasarsRequest request)
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
