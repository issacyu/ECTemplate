using System.ComponentModel.DataAnnotations;

namespace ECTemplate.Domain.Entities
{
    public class LookUps
    {
        [Key]
        public int LookUpId { get; set; }

        public int UserId { get; set; }
        
        public int AddressId { get; set; }

        public int OrderId { get; set; }
    }
}
