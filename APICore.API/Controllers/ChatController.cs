using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APICore.API.BasicResponses;
using APICore.Common.DTO.Request;
using APICore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IChatService _cht;

        public ChatController(IChatService cht)
        {
            _cht = cht;
        }

        [HttpPost("sendmessage")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest requestData)
        {
            try
            {
                var response = await _cht.SendMessage(requestData);
                return Ok(new ApiOkResponse(response));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}