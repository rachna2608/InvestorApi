using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorApi.Domain.DTOs
{
    public class InvestorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public decimal TotalCommitment { get; set; }
        public DateTime? DateAdded { get; set; }
    }

}
