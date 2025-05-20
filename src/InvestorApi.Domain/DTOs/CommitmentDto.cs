using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorApi.Domain.DTOs
{
    public class CommitmentDto
    {
        public int Id { get; set; }
        public string AssetClass { get; set; }
        public string Currency { get; set; }
        public decimal AmountGBP { get; set; }
    }

}
