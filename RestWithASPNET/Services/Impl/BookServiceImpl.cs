using RestWithASPNET.Model;
using RestWithASPNET.Repositories;

namespace RestWithASPNET.Services.Impl;

public class BookServiceImpl : IBookServices
{
    private IRepository<Book> _repository;

    public BookServiceImpl (IRepository<Book> repository)
    {
        _repository = repository;
    }

    public Book Create(Book book) 
    {
        return _repository.Create(book);
    }
    public Book FindById(long id) 
    {
        return _repository.FindById(id);
    }
    public List<Book> FindAll() 
    {
        return _repository.FindAll();
    }
    public Book Update(Book book) 
    {
        return _repository.Update(book);
    }
    public void Delete(long id) 
    {
        _repository.Delete(id);
    }
}
