using MyNoSqlServer.Abstractions;

namespace MyJetWallet.Unlimint.MyNoSql
{
    public class ConvenienceStoreNoSqlEntity : MyNoSqlDbEntity
    {
        public const string TableName = "myjetwallet-unlimint-convenience-store-methods";
        public static string GeneratePartitionKey(string country) => country;
        public static string GenerateRowKey(string country, string unlimintMethodId) => $"UCS-{unlimintMethodId.ToUpper()}-{country.ToUpper()}";

        public static ConvenienceStoreNoSqlEntity Create(string unlimintMethodId, string country, string currency, bool enabled)
        {
            var rowKey = GenerateRowKey(country, unlimintMethodId);
            return new ConvenienceStoreNoSqlEntity()
            {
                PartitionKey = GeneratePartitionKey(country),
                RowKey = rowKey,
                Id = rowKey,
                UnlimintMethodId = unlimintMethodId,
                Country = country,
                Currency = currency,
                Enabled = enabled
            };
        }

        public string Id { get; set; }
        public string UnlimintMethodId { get; set;}
        public string Country { get; set;}
        public string Currency { get; set;}
        public bool Enabled { get; set;}
    }
}