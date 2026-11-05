using FluentAssertions;
using RestWithASPNET.Data.Converter.Impl;
using RestWithASPNET.Data.DTO.V2;
using RestWithASPNET.Model;

namespace RestWithASPNET.Tests;

public class PersonConverterTests
{
    private readonly PersonConverterV2 _converter;
    public PersonConverterTests()
    {
        _converter = new PersonConverterV2();
    }
    // Person DTO to Person conversion tests
    [Fact]
    public void Parse_ShouldConvertPersonDTOToPerson()
    {
        // Arrange
        var DTO = new PersonDTO
        {
            Id = 1,
            FirstName = "Lucio",
            SecondName = "Madri",
            Age = 22,
            Cpf = "12345678912",
            Gender = "M",
            Birthday = new DateTime(2000, 10, 2)
        };
        var expectedPerson = new Person
        {
            Id = 1,
            FirstName = "Lucio",
            SecondName = "Madri",
            Age = 22,
            Cpf = "12345678912",
            Gender = "M",
        };
        // Act
        var person = _converter.Parse(DTO);
        // Assert
        person.Should().NotBeNull();
        person.Id.Should().Be(expectedPerson.Id);
        person.FirstName.Should().Be(expectedPerson.FirstName);
        person.SecondName.Should().Be(expectedPerson.SecondName);
        person.Age.Should().Be(expectedPerson.Age);
        person.Cpf.Should().Be(expectedPerson.Cpf);
        person.Gender.Should().Be(expectedPerson.Gender);
        person.Should().BeEquivalentTo(expectedPerson);
    }
    // Verefic null Person DTO return null
    [Fact]
    public void Parse_NullPersonDTOShouldReturnNull()
    {
        // Arrange
        PersonDTO? dto = null;
        // Act
        var person = _converter.Parse(dto);
        // Assert 
        person.Should().BeNull();
    }
    // Person -> PersonDto
    [Fact]
    public void Parse_ShouldConvertPersonToPersonDTO()
    {
        // Arrange
        var entity = new Person
        {
            Id = 1,
            FirstName = "Lucio",
            SecondName = "Madri",
            Age = 22,
            Cpf = "12345678912",
            Gender = "M",
            //Birthday = new DateTime(2000, 10, 2)
        };
        var expectedPerson = new PersonDTO
        {
            Id = 1,
            FirstName = "Lucio",
            SecondName = "Madri",
            Age = 22,
            Cpf = "12345678912",
            Gender = "M"
        };
        // Act
        var person = _converter.Parse(entity);
        // Assert
        person.Should().NotBeNull();
        person.Id.Should().Be(expectedPerson.Id);
        person.FirstName.Should().Be(expectedPerson.FirstName);
        person.SecondName.Should().Be(expectedPerson.SecondName);
        person.Age.Should().Be(expectedPerson.Age);
        person.Cpf.Should().Be(expectedPerson.Cpf);
        person.Gender.Should().Be(expectedPerson.Gender);
        person.Should().BeEquivalentTo(expectedPerson, options => options.Excluding(person => person.Birthday));
        person.Birthday.Should().NotBeNull();
    }
    // Verefic null Person return null
    [Fact]
    public void Parse_NullPersonShouldReturnNull()
    {
        // Arrange
        Person? dto = null;
        // Act
        var person = _converter.Parse(dto);
        // Assert 
        person.Should().BeNull();
    }
    // Person DTO lis to Person List conversion Tests
    [Fact]
    public void ParseList_ShouldConvertPersonDTOToPerson()
    {
        // Arrange
        var dtoList = new List<PersonDTO>
        {
            new PersonDTO{
            Id = 1,
            FirstName = "Lucio",
            SecondName = "Madri",
            Age = 22,
            Cpf = "12345678912",
            Gender = "M",
            Birthday = new DateTime(2000, 10, 2)
            },
            new PersonDTO{
            Id = 2,
            FirstName = "Maria",
            SecondName = "Prado",
            Age = 30,
            Cpf = "12345678913",
            Gender = "F",
            Birthday = new DateTime(1980, 10, 2)
            },
            new PersonDTO{
            Id = 3,
            FirstName = "Francineis",
            SecondName = "Rodrigues",
            Age = 30,
            Cpf = "12345678914",
            Gender = "F",
            Birthday = new DateTime(2000, 11, 2)
            }
        };
        // Act
        var personList = _converter.ParseList(dtoList);
        // Assert
        personList.Should().NotBeNull();
        personList.Should().HaveCount(3);
        personList[0].Should().BeEquivalentTo(new Person
        {
            Id = 1,
            FirstName = "Lucio",
            SecondName = "Madri",
            Age = 22,
            Cpf = "12345678912",
            Gender = "M"
        });
        personList[1].Should().BeEquivalentTo(new Person
        {
            Id = 2,
            FirstName = "Maria",
            SecondName = "Prado",
            Age = 30,
            Cpf = "12345678913",
            Gender = "F",
        });
        personList[2].Should().BeEquivalentTo(new Person
        {
            Id = 3,
            FirstName = "Francineis",
            SecondName = "Rodrigues",
            Age = 30,
            Cpf = "12345678914",
            Gender = "F",
        });
    }
    // Verefic null list Person DTO return list null
    [Fact]
    public void ParseList_NullPersonDTOShouldReturnNull()
    {
        // Arrange
        List<PersonDTO>? dto = null;
        // Act
        var personList = _converter.ParseList(dto);
        // Assert 
        personList.Should().BeNull();
    }
    // Person list to Person List conversion Tests
    [Fact]
    public void ParseList_ShouldConvertPersonToPersonDTO()
    {
        // Arrange
        var Listing = new List<Person>
        {
            new Person{
            Id = 1,
            FirstName = "Lucio",
            SecondName = "Madri",
            Age = 22,
            Cpf = "12345678912",
            Gender = "M",
            //Birthday = new DateTime(2000, 10, 2)
            },
            new Person{
            Id = 2,
            FirstName = "Maria",
            SecondName = "Prado",
            Age = 30,
            Cpf = "12345678913",
            Gender = "F",
            //Birthday = new DateTime(1980, 10, 2)
            },
            new Person{
            Id = 3,
            FirstName = "Francineis",
            SecondName = "Rodrigues",
            Age = 30,
            Cpf = "12345678914",
            Gender = "F",
            //Birthday = new DateTime(2000, 11, 2)
            }
        };

        var expectedListingDTO = new List<PersonDTO>
        {
            new PersonDTO{
            Id = 1,
            FirstName = "Lucio",
            SecondName = "Madri",
            Age = 22,
            Cpf = "12345678912",
            Gender = "M",
            //Birthday = new DateTime(2000, 10, 2)
            },
            new PersonDTO{
            Id = 2,
            FirstName = "Maria",
            SecondName = "Prado",
            Age = 30,
            Cpf = "12345678913",
            Gender = "F",
            //Birthday = new DateTime(1980, 10, 2)
            },
            new PersonDTO{
            Id = 3,
            FirstName = "Francineis",
            SecondName = "Rodrigues",
            Age = 30,
            Cpf = "12345678914",
            Gender = "F",
            //Birthday = new DateTime(2000, 11, 2)
            }
        };
        // Act
        var personDTOList = _converter.ParseList(Listing);
        // Assert
        personDTOList.Should().NotBeNull();
        personDTOList.Should().HaveCount(3);
        for (int i = 0; i < 3; i++)
        {
            personDTOList[i].Should().BeEquivalentTo(expectedListingDTO[i], options => options.Excluding(personDTO => personDTO.Birthday));
            personDTOList[i].Birthday.Should().NotBeNull();
            personDTOList[i].Id.Should().Be(expectedListingDTO[i].Id);
            personDTOList[i].FirstName.Should().Be(expectedListingDTO[i].FirstName);
            personDTOList[i].SecondName.Should().Be(expectedListingDTO[i].SecondName);
            personDTOList[i].Age.Should().Be(expectedListingDTO[i].Age);
            personDTOList[i].Cpf.Should().Be(expectedListingDTO[i].Cpf);
            personDTOList[i].Gender.Should().Be(expectedListingDTO[i].Gender);
        }
    }
    // Verefic null list Person DTO return list null
    [Fact]
    public void ParseList_NullPersonShouldReturnNull()
    {
        // Arrange
        List<Person>? dto = null;
        // Act
        var personList = _converter.ParseList(dto);
        // Assert 
        personList.Should().BeNull();
    }

}