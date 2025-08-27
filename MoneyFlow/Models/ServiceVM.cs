using MoneyFlow.Models.Entities;

namespace MoneyFlow.Models
{
    public class ServiceVM
    {
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

    }
}
