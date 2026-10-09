using RestWithASPNET.Data.Converter.Impl;
using RestWithASPNET.Data.DTO;
using RestWithASPNET.Model;
using RestWithASPNET.Repositories;
namespace RestWithASPNET.Services.Impl;

public class PersonServiceImpl : IPersonServices
{
    private IRepository<Person> _repository;
    private readonly PersonConverter _converter;
    public PersonServiceImpl(IRepository<Person> repository)
    {
        _repository = repository;
        _converter = new PersonConverter();
    }

    public PersonDTO Create(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Create(entity);
        return _converter.Parse(entity);
    }

    public PersonDTO FindById(long Id)
    {
        return _converter.Parse(_repository.FindById(Id));
    }

    public List<PersonDTO> FindAll()
    {
        return _converter.ParseList(_repository.FindAll());
    }

    public PersonDTO Update(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Update(entity);
        return _converter.Parse(entity);
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }
}
