using CsvHelper.Configuration.Attributes;

namespace InvestorApi.Infrastructure.SeedData
{
    public class InvestorCsvRecord
    {
        [Name("Investor Name")]
        public string InvestorName { get; set; }

        [Name("Investory Type")]
        public string InvestorType { get; set; }

        [Name("Investor Country")]
        public string Address { get; set; }

        [Name("Investor Date Added")]
        public DateTime DateAdded { get; set; }

        [Name("Investor Last Updated")]
        public DateTime LastUpdated { get; set; }

        [Name("Commitment Asset Class")]
        public string AssetClass { get; set; }

        [Name("Commitment Currency")]
        public string Currency { get; set; }

        [Name("Commitment Amount")]
        public decimal AmountGBP { get; set; }
    }

}
