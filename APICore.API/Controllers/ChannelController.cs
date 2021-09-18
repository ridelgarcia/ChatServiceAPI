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
    public class ChannelController : ControllerBase
    {
        private IChannelService _srv;

        public ChannelController(IChannelService srv)
        {
            _srv = srv;
        }

        [HttpPost("addchannel")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddChannel([FromBody] AddChannelRequest requestData)
        {
            try
            {
                var response = await _srv.AddChannel(requestData);
                return Ok(new ApiOkResponse(response));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}