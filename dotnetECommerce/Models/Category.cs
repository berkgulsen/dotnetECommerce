using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dotnetECommerce.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required, DisplayName("Category Name"), MaxLength(30)]
    public string Name { get; set; }
    [DisplayName("Display Order"), Range(1,200)]
    public int DisplayOrder { get; set; }
}