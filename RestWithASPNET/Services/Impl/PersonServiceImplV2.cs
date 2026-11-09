using RestWithASPNET.Data.Converter.Impl;
using RestWithASPNET.Data.DTO.V2;
using RestWithASPNET.Model;
using RestWithASPNET.Repositories;
namespace RestWithASPNET.Services.Impl;

public class PersonServiceImplV2 
{
    private IRepository<Person> _repository;
    private readonly PersonConverterV2 _converter;
    public PersonServiceImplV2(IRepository<Person> repository)
    {
        _repository = repository;
        _converter = new PersonConverterV2();
    }

    public PersonDTO Create(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Create(entity);
        return _converter.Parse(entity);
    }
}
