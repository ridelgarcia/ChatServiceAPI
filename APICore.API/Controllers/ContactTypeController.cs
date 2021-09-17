using APICore.API.BasicResponses;
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
    public class ContactTypeController : ControllerBase
    {
        private IContactTypeService _cts;

        public ContactTypeController(IContactTypeService cts)
        {
            _cts = cts;
        }

        [HttpGet("getallcontacttypes")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllContactTypes()
        {
            try
            {
                var response = await _cts.GetAllContactTypes();
                return Ok(new ApiOkResponse(response));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}