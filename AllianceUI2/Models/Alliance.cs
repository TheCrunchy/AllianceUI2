namespace AllianceUI2.Models
{
    //this isnt great, need to make an alliances dll that has the stuff that can be referenced without needing sandbox dll loaded
    public class Alliance
    {
        public Boolean IsOpenToAll = false;
        public Guid AllianceId = System.Guid.NewGuid();
        public String name;
        public String description;
        public ulong SupremeLeader;
        public string LeaderTitle = "Supreme Leader";
        public Boolean AllowElections = false;
        public List<long> BlockedFactions = new List<long>();
        public Dictionary<ulong, String> otherTitles = new Dictionary<ulong, string>();
        public string DiscordToken = string.Empty;
        public ulong DiscordChannelId = 0;
        public List<String> enemies = new List<String>();
        public List<long> EnemyFactions = new List<long>();
        public List<String> friendlies = new List<String>();
        public List<long> FriendlyFactions = new List<long>();
        public int reputation = 0;
        public List<long> Invites = new List<long>();
        public List<long> AllianceMembers = new List<long>();
        public int GridRepairUpgrade = 0;
        public long bankBalance = 0;
        public Boolean hasUnlockedShipyard = false;
        public Boolean hasUnlockedHangar = false;
        public List<string> EditorKicks = new List<string>();
        public List<string> EditorInvites = new List<string>();
        public Dictionary<String, RankPermissions> CustomRankPermissions = new Dictionary<string, RankPermissions>();
        public Dictionary<ulong, String> PlayersCustomRank = new Dictionary<ulong, string>();
        public RankPermissions UnrankedPerms = new RankPermissions();
        public int CurrentMetaPoints = 0;
        public Dictionary<string, string> inheritance = new Dictionary<string, string>();
        public Dictionary<ulong, RankPermissions> playerPermissions = new Dictionary<ulong, RankPermissions>();
        public float leadertax = 0;
        public bool ElectionCycle = false;
        public long ShipyardFee = 25000000;
        public int r = 66;
        public int g = 163;
        public int b = 237;
        public int failedUpkeep = 0;
        public int RefineryUpgradeLevel = 0;
        public int AssemblerUpgradeLevel = 0;

        public Boolean ForceFriends = true;
    }

    public class RankPermissions
    {
        public List<AccessLevel> permissions { get; set; } = new List<AccessLevel>();
        public int permissionLevel { get; set; }
        public float taxRate { get; set; }
        public string RankName { get; set; }
        public string Key { get; set; }
    }

    public enum AccessLevel
    {
        HangarSave,
        HangarLoad,
        HangarLoadOther,
        BankWithdraw,
        ShipyardStart,
        ShipyardClaim,
        ShipyardClaimOther,
        DividendPay,
        Invite,
        Kick,
        RevokeLowerTitle,
        GrantLowerTitle,
        UnlockUpgrades,
        RemoveEnemy,
        AddEnemy,
        PayFromBank,
        Vote,
        RecieveDividend,
        TaxExempt,
        ChangeTax,
        GrindInSafeZone,
        UnableToParse,
        Everything

    }
}
