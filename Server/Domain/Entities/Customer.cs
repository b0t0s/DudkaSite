using System.ComponentModel.DataAnnotations;

namespace Site.Server.Domain.Entities;

public class Customer
{
    [Key] [Required] public int Id { get; set; }
}