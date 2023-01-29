using AlliancesPlugin;
using AlliancesPlugin.Alliances;

namespace AllianceUI2.Data
{
    public class DataService
    {
        public Alliance GetData(Guid id)
        {
            return new Alliance()
            {
                name = "This is test data",
                CustomRankPermissions = new Dictionary<string, RankPermissions>()
                {
                    {
                       "test",
                       new RankPermissions()
                        {
                            RankName = "test",
                            taxRate = 5,
                            permissionLevel = 100
                        }
                    }
                    ,
                    {  "test2",
                      new RankPermissions()
                        {
                            RankName = "test2",
                            taxRate = 3,
                            permissionLevel = 101
                        }
                    }
                    ,
                    {  "test3",
                      new RankPermissions()
                        {
                            RankName = "Alan",
                            taxRate = 100,
                            permissionLevel = 99
                        }
                    }
                    ,
                    {  "test4",
                      new RankPermissions()
                        {
                            RankName = "Dave",
                            taxRate = 1,
                            permissionLevel = 45
                        }
                    }
                }
            };
        }
    }
}

