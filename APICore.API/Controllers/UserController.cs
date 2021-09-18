using APICore.API.BasicResponses;
using APICore.Common.DTO.Request;
using APICore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace APICore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _usrs;

        public UserController(IUserService usrs)
        {
            _usrs = usrs;
        }

        [HttpPost("getcontactlist")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetContactList([FromBody] GetContactListRequest requestData)
        {
            try
            {
                var response = await _usrs.GetContactList(requestData);
                return Ok(new ApiOkResponse(response));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost("changeuserstatus")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ChangeUserStatus([FromBody] ChangeUserStatusRequest requestData)
        {
            try
            {
                var response = await _usrs.ChanageUserStatus(requestData);
                return Ok(new ApiOkResponse(response));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}