using APICatalog.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalog.Domain;

[Table("Products")]
public class Product : IValidatableObject
{
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "The field 'name' is required")]
    [StringLength(20, ErrorMessage = "The name must be between 5 and 20 characters", MinimumLength = 5)]
    //[PrimeiraLetraMaiuscula]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The field 'Description' is required")]
    [StringLength(10, ErrorMessage = "The description must be between 5 and 10 characters", MinimumLength = 5)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    [Range(1,10000, ErrorMessage = "The price must be between {1} and {2}")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The field 'ImageUrl' is required")]
    [StringLength(300, MinimumLength = 10)]
    public string? ImageUrl { get; set; }
    public float Stock { get; set; }
    public DateTime registrationDate { get; set; }
    public int CategoryId { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(this.Name))
        {
            var primeiraLetra = this.Name[0].ToString();
            if(primeiraLetra != primeiraLetra.ToUpper())
            {
                yield return new
                    ValidationResult("A primeira letra do nome do produto deve ser maiúscula",
                    new[]
                    { nameof(this.Name)}
                    );
            }
        }

        if(this.Stock <=0)
        {
            yield return new
                    ValidationResult("O estoque deve ser maior que zero",
                    new[]
                    { nameof(this.Stock)}
                    );
        }
    }
}
