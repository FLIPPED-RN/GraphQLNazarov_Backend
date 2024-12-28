using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExampleGraphQL.Models
{
    public class Hall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Capacity { get; set; }
        public ICollection<Session>? Sessions { get; set; }
    }
}
