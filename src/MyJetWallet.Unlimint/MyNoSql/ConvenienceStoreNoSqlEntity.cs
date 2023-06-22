using MyNoSqlServer.Abstractions;

namespace MyJetWallet.Unlimint.MyNoSql
{
    public class ConvenienceStoreNoSqlEntity : MyNoSqlDbEntity
    {
        public const string TableName = "myjetwallet-unlimint-convenience-store-methods";
        public static string GeneratePartitionKey(string country) => country;
        public static string GenerateRowKey(string unlimintMethodName) => unlimintMethodName;

        public static ConvenienceStoreNoSqlEntity Create(string unlimintMethodName, int id, string country, string currency, bool enabled)
        {
            return new ConvenienceStoreNoSqlEntity()
            {
                PartitionKey = GeneratePartitionKey(country),
                RowKey = GenerateRowKey(unlimintMethodName),
                Id = id,
                UnlimintMethodId = unlimintMethodName,
                Country = country,
                Currency = currency,
                Enabled = enabled
            };
        }

        public int Id { get; set; }
        public string UnlimintMethodId { get; set;}
        public string Country { get; set;}
        public string Currency { get; set;}
        public bool Enabled { get; set;}
    }
}