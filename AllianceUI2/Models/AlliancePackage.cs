
namespace AllianceUI2.Models
{
    public class AlliancePackage
    {
        public Dictionary<ulong, string> SteamIdsAndNames = new Dictionary<ulong, string>();
        public Dictionary<long, string> FactionNames = new Dictionary<long, string>();
        public Dictionary<Guid, string> OtherAlliances = new Dictionary<Guid, string>();
        public Alliance AllianceData;
        public Guid EditId;
        public ulong SteamId;
        public DateTime DateEdited;
        public DateTime ExpiresAt;
    }
}