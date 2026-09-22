using RestWithASPNET.Model;
namespace RestWithASPNET.Services.Impl;

public class PersonServiceImpl : IPersonServices
{
    private Person mockPerson(int i,string firstName = "Jhon",string secondName = "Ninhares", int age = 18 , string cpf = "177.671.888-90", char gender = 'M')
    {
        var person = new Person{Id = new Random().Next(1,1000), FirstName = firstName + i,SecondName = secondName + i, Age = age, Cpf = cpf, Gender = gender };
        return person;
    }
    public Person Create(Person person)
    {
        person.Id = new Random().Next(1,1000);
        return person;
    }

    public Person FindById(long Id)
    {
        var person = mockPerson((int)Id);
        return person;
    }

    public List<Person> FindAll()
    {
        List<Person> persons = new List<Person>();
        for(int i = 0; i < 10; i++)
        {
            persons.Add(mockPerson(i));
        }
        return persons;
    }

    public Person Update(Person person)
    {
        return person;
    }

    public void Delete(long id)
    {
        // Logica de deleção
    }
}
