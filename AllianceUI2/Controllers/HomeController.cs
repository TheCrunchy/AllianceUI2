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
            foreach (var rank in alliance.AllianceData.CustomRankPermissions)
            {
                while (rank.Value.taxRate < 1 && rank.Value.taxRate != 0)
                {
                    rank.Value.taxRate *= 100;
                }
            }
            while (alliance.AllianceData.leadertax < 1 && alliance.AllianceData.leadertax != 0)
            {
                alliance.AllianceData.leadertax *= 100;
            }
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
            foreach (var rank in alliance.AllianceData.CustomRankPermissions)
            {
                while (rank.Value.taxRate > 1)
                {
                    rank.Value.taxRate /= 100;
                }
            }
            while (alliance.AllianceData.leadertax > 1)
            {
                alliance.AllianceData.leadertax /= 100;
            }
            string allianceJson = JsonConvert.SerializeObject(alliance);
            return Ok(allianceJson);
        }
    }
}
