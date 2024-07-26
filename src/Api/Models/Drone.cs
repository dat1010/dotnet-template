using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class Drone
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Frame { get; set; }

    [Required]
    [StringLength(255)]
    public string Motor { get; set; }

    [Required]
    [StringLength(255)]
    public string VideoTransmitterType { get; set; }

    [Required]
    [StringLength(255)]
    public string Receiver { get; set; }
}
