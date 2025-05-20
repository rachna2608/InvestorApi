using InvestorApi.Domain.DTOs;
using InvestorApi.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace InvestorApi.Controllers
{
    [ApiController]
    [Route("api/investors")]
    public class InvestorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvestorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InvestorDto>> GetInvestors()
        {
            var investors = _context.Investors
                .Select(i => new InvestorDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type,
                    Address = i.Address,
                    TotalCommitment = i.TotalCommitment,
                    DateAdded = i.DateAdded
                }).ToList();

            return Ok(investors);
        }

        [HttpGet("{id}/commitments")]
        public ActionResult<IEnumerable<CommitmentDto>> GetCommitments(int id, [FromQuery] string? assetClass)
        {
            var commitments = _context.Commitments
                .Where(c => c.InvestorId == id);

            if (!string.IsNullOrEmpty(assetClass) && assetClass.ToLower() != "all")
            {
                commitments = commitments.Where(c => c.AssetClass.ToLower() == assetClass.ToLower());
            }

            return Ok(commitments.Select(c => new CommitmentDto
            {
                Id = c.Id,
                AssetClass = c.AssetClass,
                Currency = c.Currency,
                AmountGBP = c.AmountGBP
            }).ToList());
        }
    }

}
