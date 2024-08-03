
namespace MAUItestworkForRobotX.Authentification
{
    public class AuthResponseData
    {
        public int ApiAccessTokenId { get; set; }
        public Client Client { get; set; }
        public string Token { get; set; }
        public object EpirationDate { get; set; }
        public object Message { get; set; }
        public object ClientGifts { get; set; }
        public object DeviceName { get; set; }
        public object DeviceVersion { get; set; }
        public object LastLoginTime { get; set; }
    }

    public class Client
    {
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneMobile { get; set; }
        public object Email { get; set; }
        public float Balance { get; set; }
        public Card[] Cards { get; set; }
        public object ClientPromoCode { get; set; }
        public float Turnover { get; set; }
        public object ClientChipInfo { get; set; }
    }

    public class Card
    {
        public int CardId { get; set; }
        public int AccountId { get; set; }
        public string CardCode { get; set; }
        public bool Blocked { get; set; }
        public object BlockedString { get; set; }
        public bool AccumulateOnly { get; set; }
        public object AccumulateOnlyString { get; set; }
        public int CardStatusId { get; set; }
        public object StartDate { get; set; }
        public object FinishDate { get; set; }
        public string BonusProgramName { get; set; }
        public object Algorithm { get; set; }
        public int BonusProgramId { get; set; }
        public int BonusProgramTypeId { get; set; }
        public float Balance { get; set; }
        public float Discount { get; set; }
        public float Turnover { get; set; }
        public bool HasSales { get; set; }
        public bool IsSuspicious { get; set; }
        public object CreateByMarketProgramId { get; set; }
        public object CardType { get; set; }
        public object AccountTypeName { get; set; }
        public bool IsPromoCard { get; set; }
        public object WalletBarCodeFormatId { get; set; }
        public int AccountTypeId { get; set; }
    }

}
