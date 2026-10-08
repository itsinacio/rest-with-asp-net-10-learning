using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithASPNET.Model.Base;

namespace RestWithASPNET.Model;
[Table("person")]
public class Person : BaseEntity
{
    [Required]
    [Column("firstName",TypeName = "varchar(50)")]
    [MaxLength(50)]
    public string FirstName {get ; set;} = string.Empty;
    [Required]
    [Column("secondName",TypeName = "varchar(50)")]
    [MaxLength(50)]
    public string SecondName {get ; set;}  = string.Empty;
    [Column("age")]
    public int Age {get ; set;}
    [Required]
    [Column("cpf",TypeName = "varchar(11)")]
    [MaxLength(11)]
    public string Cpf {get ; set;}  = string.Empty;
    [Required]
    [Column("gender",TypeName = "char(1)")]
    [MaxLength(1)]
    public string Gender {get ; set;} = string.Empty;
}
