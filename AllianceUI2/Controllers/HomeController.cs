using AllianceUI2.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AllianceUI2.Models;

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

        [HttpPost]
        public IActionResult PostAlliance([FromBody] object allianceJson)
        {
            try
            {
                AlliancePackage alliance = JsonConvert.DeserializeObject<AlliancePackage>(allianceJson.ToString());
                // AlliancePackage alliance = allianceJson;
                alliance.AllianceData.CustomRankPermissions.Remove("Unranked");
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
            catch (Exception e)
            {
                return Ok(e.ToString());
            }
        }

        [HttpGet]
        public IActionResult GetAlliance(ulong id)
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
            alliance.AllianceData.CustomRankPermissions.Remove("Unranked");
            string allianceJson = JsonConvert.SerializeObject(alliance.AllianceData);
            return Ok(allianceJson);
        }
    }
}
