using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExampleGraphQL.Models
{
    public class Ticket
    {
        public Ticket()
        {
            Session = new Session();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid SessionId { get; set; }

        public Session Session { get; set; }

        [Required]
        public int SeatNumber { get; set; }

        [Required]
        public bool IsSold { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
