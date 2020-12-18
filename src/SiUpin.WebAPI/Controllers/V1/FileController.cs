using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.Files.Commands.CreateFile;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class FileController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] CreateFileRequest request)
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
