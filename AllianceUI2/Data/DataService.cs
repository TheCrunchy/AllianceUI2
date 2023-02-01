using AlliancesPlugin;
using AlliancesPlugin.Alliances;

namespace AllianceUI2.Data
{
    public class DataService
    {
        private Dictionary<Guid, AlliancePackage> Data = new Dictionary<Guid, AlliancePackage>();
        public AlliancePackage GetPackage(Guid id)
        {
            if (Data.TryGetValue(id, out var package))
            {
                return package;
            }
            return null;

        }
    
        public void StoreData(AlliancePackage package)
        {
            if (!Data.ContainsKey(package.EditId))
            {
                Data.Add(package.EditId, package);
            }
        }
    }
}

