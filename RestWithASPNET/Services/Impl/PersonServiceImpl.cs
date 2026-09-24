using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
namespace RestWithASPNET.Services.Impl;

public class PersonServiceImpl : IPersonServices
{
    private MSSQLContext _context;
    public PersonServiceImpl(MSSQLContext context)
    {
        _context = context;
    }

    public Person Create(Person person)
    {
        _context.Add(person);
        _context.SaveChanges();
        return person;
    }

    public Person FindById(long Id)
    {
        return _context.Persons.Find(Id);
    }

    public List<Person> FindAll()
    {
        return _context.Persons.ToList();
    }

    public Person Update(Person person)
    {
        var existingPerson = _context.Persons.Find(person.Id);
        if(existingPerson == null) return null;
        _context.Entry(existingPerson).CurrentValues.SetValues(person);
        _context.SaveChanges();
        return person;
    }

    public void Delete(long id)
    {
        var existingPerson = _context.Persons.Find(id);
        if(existingPerson == null) return ;
        _context.Remove(existingPerson);
        _context.SaveChanges();
    }
}
