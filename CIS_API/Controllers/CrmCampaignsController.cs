using CIS.Db;
using CIS.DTOs;
using CIS.Interfaces;
using CIS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrmCampaignsController : ControllerBase
    {
        private ICrmCampaignDb db;
        private ApplicationDbContext dbContext;

        public CrmCampaignsController(ICrmCampaignDb db, ApplicationDbContext dbContext)
        {
            this.db = db;   
            this.dbContext = dbContext; 
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.dbContext.Campaigns.ToList());
            }catch
            {
                return BadRequest();
            }
        }
    }
}
