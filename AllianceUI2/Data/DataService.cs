using AllianceUI2.Models;

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
        public AlliancePackage GetPackage(ulong id)
        {
            var result = Data.Where(x => x.Value.SteamId == id);
            if (result == null || !result.Any())
            {
                return null;
            }
            var lastEdited = result.OrderByDescending(x => x.Value.DateEdited);
  
            return lastEdited.First().Value;
        }
    
        public void StoreData(AlliancePackage package)
        {
            List<Guid> RemoveThese = new List<Guid>();
            foreach (var item in Data.Values)
            {
                if (DateTime.Now >= item.ExpiresAt)
                {
                    RemoveThese.Add(item.EditId);
                }
            }
            foreach (var item in RemoveThese)
            {
                Data.Remove(item);
            }
            if (!Data.ContainsKey(package.EditId))
            {
                Data.Add(package.EditId, package);
            }
        }

        public void SaveChanges(Guid id, Alliance alliance)
        {
            var data = Data[id];
            data.DateEdited = DateTime.Now;
            data.AllianceData = alliance;
            Data[id] = data;
        }
    }
}

