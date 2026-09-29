using RestWithASPNET.Model;
using RestWithASPNET.Repositories;
namespace RestWithASPNET.Services.Impl;

public class PersonServiceImpl : IPersonServices
{
    private IPersonRepository _repository;
    public PersonServiceImpl(IPersonRepository repository)
    {
        _repository = repository;
    }

    public Person Create(Person person)
    {
        return _repository.Create(person);
    }

    public Person FindById(long Id)
    {
        return _repository.FindById(Id);
    }

    public List<Person> FindAll()
    {
        return _repository.FindAll();
    }

    public Person Update(Person person)
    {
        return _repository.Update(person);
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }
}
