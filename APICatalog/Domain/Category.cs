using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalog.Domain;

[Table("Categories")]
public class Category
{

    public Category()
    {
            Products = new Collection<Product>();
    }
    [Key]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "The field 'name' is required")]
    [StringLength(80)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The field 'ImageUrl' is required")]
    [StringLength(300)]
    public string? ImageUrl { get; set; }
    public ICollection<Product>? Products { get; set; }



}
