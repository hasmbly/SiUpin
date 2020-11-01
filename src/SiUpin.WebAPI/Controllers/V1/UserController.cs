using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.Users.Commands.CreateUser;
using SiUpin.WebAPI.Common.ApiEnvelopes;


namespace SiUpin.WebAPI.Controllers.V1
{
    public class UserController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Register(CreateUserRequest request)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(request), "User Created successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }
    }
}