using MoneyFlow.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MoneyFlow.Models
{
    public class ServiceVM
    {
        public int ServiceId { get; set; }
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Type { get; set; }

    }
}
