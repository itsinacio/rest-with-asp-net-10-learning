namespace RestWithASPNET.Data.DTO.V1;
public class BookDTO 
{
    public long Id {get; set;}
    public string Title {get; set;}
    public string Author {get; set;}
    public decimal price {get; set;}
    public DateTime launchDate {get; set;}
}
