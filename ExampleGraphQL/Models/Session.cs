using ExampleGraphQL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Session
{
    public Session()
    {
        Movie = new Movie();
        Hall = new Hall();
        Tickets = new List<Ticket>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    public Guid MovieId { get; set; }

    public Movie Movie { get; set; }

    [Required]
    public Guid HallId { get; set; }

    public Hall Hall { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}