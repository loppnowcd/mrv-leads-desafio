using System.ComponentModel.DataAnnotations;

namespace MRVLeads
{
    public class Lead
    {
        public int Id { get; set; }

        [Required]
        public string ContactFirstName { get; set; } = string.Empty;

        public string ContactFullName { get; set; } = string.Empty;

        public string ContactPhone { get; set; } = string.Empty;

        public string ContactEmail { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; }

        public string Suburb { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Status { get; set; } = "New"; // New, Accepted, Declined
    }
}