using AllianceUI2.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AlliancesPlugin.Alliances;

namespace AllianceUI2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AllianceController : ControllerBase
    {
        private DataService dataService;

        public AllianceController(DataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpGet]
        public IActionResult PostAlliance(string allianceJson)
        {
            AlliancePackage alliance = JsonConvert.DeserializeObject<AlliancePackage>(allianceJson);
            alliance.AllianceData.CustomRankPermissions.Add("Unranked", alliance.AllianceData.UnrankedPerms);
            dataService.StoreData(alliance);
            return Ok(alliance);
        }

        [HttpGet]
        public IActionResult GetAlliance(Guid id)
        {
            AlliancePackage alliance = dataService.GetPackage(id);
            if (alliance == null)
            {
                return NotFound();
            }

            string allianceJson = JsonConvert.SerializeObject(alliance);
            return Ok(allianceJson);
        }
    }
}
