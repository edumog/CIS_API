using CIS.DTOs;
using CIS.Interfaces;
using CIS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardizerController : ControllerBase
    {
        private StandardizationContract standardizationService;
        public StandardizerController(StandardizationContract standardizationService)
        {
            this.standardizationService = standardizationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new ClientDTO()
            {
                Name= "eduardo"
            });
        }

        [HttpPost]
        public IActionResult GetClients([FromForm] StandardizationParameters form)
        {
            try
            {
                IList<ClientDTO> clients = standardizationService.GetClients(form);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
