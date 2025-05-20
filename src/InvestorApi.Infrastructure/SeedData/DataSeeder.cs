using CsvHelper;
using CsvHelper.Configuration;
using InvestorApi.Domain.Models;
using InvestorApi.Infrastructure.Data;
using System.Globalization;

namespace InvestorApi.Infrastructure.SeedData
{
    public class DataSeeder
    {
        public static void SeedFromCsv(ApplicationDbContext context)
        {
            if (context.Investors.Any()) return;
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SeedData", "data.csv");
            
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            });

            var records = csv.GetRecords<InvestorCsvRecord>().ToList();

            var investors = records
                .GroupBy(r => r.InvestorName)
                .Select(g => new Investor
                {
                    Name = g.Key,
                    Type = g.First().InvestorType,
                    Address = g.First().Address,
                    TotalCommitment = g.Sum(x => x.AmountGBP),
                    DateAdded = g.First().DateAdded,
                    LastUpdated = g.First().LastUpdated,
                    Commitments = g.Select(c => new Commitment
                    {
                        AssetClass = c.AssetClass,
                        Currency = c.Currency,
                        AmountGBP = c.AmountGBP
                    }).ToList()
                }).ToList();

            context.Investors.AddRange(investors);
            context.SaveChanges();
        }
    }

}
