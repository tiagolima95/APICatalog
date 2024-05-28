using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalog.Domain;

[Table("Products")]
public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "The field 'name' is required")]
    [StringLength(80)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The field 'Description' is required")]
    [StringLength(300)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The field 'ImageUrl' is required")]
    [StringLength(300)]
    public string? ImageUrl { get; set; }
    public float Stock { get; set; }
    public DateTime registrationDate { get; set; }
    public int CategoryId { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }




}
