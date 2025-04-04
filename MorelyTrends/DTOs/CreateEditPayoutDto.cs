using System.ComponentModel.DataAnnotations;

namespace MorelyTrends.Application.DTOs
{
    public class CreateEditPayoutDto
    {
        public int? Id { get; set; } // Nullable for distinguishing create vs. edit

        public string PayoutMethod { get; set; }
        public string PayoutAccount { get; set; }
    }
}