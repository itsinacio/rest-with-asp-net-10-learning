namespace RestWithASPNET.Data.DTO.V2;
public class PersonDTO
{
    public long Id {get; set;}
    public string FirstName {get ; set;} = string.Empty;
    public string SecondName {get ; set;}  = string.Empty;
    public int Age {get ; set;}
    public string Cpf {get ; set;}  = string.Empty;
    public string Gender {get ; set;} = string.Empty;
    public DateTime? Birthday {get; set;}
}
