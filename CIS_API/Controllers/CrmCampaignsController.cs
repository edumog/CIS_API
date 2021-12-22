using CIS.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrmCampaignsController : ControllerBase
    {
        private ICrmCampaignDb db;

        public CrmCampaignsController(ICrmCampaignDb db)
        {
            this.db = db;   
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.db.GetCrmCampaigns());
            }catch
            {
                return BadRequest();
            }
        }
    }
}
