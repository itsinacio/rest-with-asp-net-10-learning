using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET.Model;
[Table("books")]
public class Book
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id {get; set;}
    [Required]
    [Column("title",TypeName = "varchar(MAX)")]
    public string Title {get; set;}
    [Required]
    [Column("author",TypeName = "varchar(MAX)")]
    public string Author {get; set;}
    [Column("price", TypeName = "decimal")]
    public decimal price {get; set;}
    [Required]
    [Column("launch_date")]
    public DateTime launchDate {get; set;}
}
