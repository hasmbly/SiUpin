using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiUpin.Shared.Users;
using SiUpin.Shared.Users.Commands.CreateUser;
using SiUpin.Shared.Users.Queries.GetUser;
using SiUpin.WebAPI.Common.ApiEnvelopes;

namespace SiUpin.WebAPI.Controllers.V1
{
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult> SignIn(GetUserRequest request)
        {
            try
            {
                return Ok(new Success(await Mediator.Send(request), "Get User successfully"));
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(exception.Message));
            }
        }
    }
}