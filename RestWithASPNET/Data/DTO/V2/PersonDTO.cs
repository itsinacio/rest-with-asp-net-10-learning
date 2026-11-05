using System.Text.Json.Serialization;
using RestWithASPNET.JsonSerializers;

namespace RestWithASPNET.Data.DTO.V2;
public class PersonDTO
{
    // [JsonPropertyOrder(7)]
    // [JsonPropertyName("code")]
    // [JsonIgnore]
    public long Id {get; set;}
    // [JsonPropertyOrder(1)]
    // [JsonPropertyName("first_name")]
    public string FirstName {get ; set;} = string.Empty;
    // [JsonPropertyOrder(2)]
    // [JsonPropertyName("second_name")]
    public string SecondName {get ; set;}  = string.Empty;
    // [JsonPropertyOrder(4)]
    public int Age {get ; set;}
    // [JsonPropertyOrder(5)]
    public string Cpf {get ; set;}  = string.Empty;
    // [JsonPropertyOrder(3)]
    [JsonConverter(typeof(GenderSerializer))]
    public string Gender {get ; set;} = string.Empty;
    // [JsonPropertyOrder(6)]
    [JsonConverter(typeof(DataSerializer))]
    public DateTime? Birthday {get; set;}
}
