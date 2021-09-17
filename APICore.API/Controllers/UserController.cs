﻿using System;
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
                Console.WriteLine("1");
                var response = await _usrs.GetContactList(requestData);
                Console.WriteLine("2");
                return Ok(new ApiOkResponse(response));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}