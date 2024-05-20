using ConsoleApp2.Domain;
using ConsoleApp2.Infrastructure.Context;
using ConsoleApp2.Services.RepositoriesAbstractions;
using ConsoleApp2.Services.ServicesContracts;

namespace ConsoleApp2.Infrastructure.Repositorires.Implementations;

public class ContactRepository : IContactRepository
{
    private readonly IContextManager _manager;
    private readonly List<Contact> _contacts;
    public ContactRepository(IContextManager manager)
    {
        _manager = manager;
        var list = _manager.LoadContactsFromFile();
        _contacts = list ?? [];
    }
    public void CreateContact(ContactCreateDto contactCreateDto)
    {
        if (contactCreateDto == null) return;
        var contact = new Contact()
        {
            Id = _contacts.Count + 1,
            Firstname = contactCreateDto.Firstname,
            Lastname = contactCreateDto.Lastname,
            Phone = contactCreateDto.Phone
        };
        _contacts.Add(contact);
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        return _contacts;
    }

    public Contact GetContactById(int id)
    {
        return _contacts.FirstOrDefault(c => c.Id == id);
    }

    public Contact UpdateContactById(int id, ContactUpdateDto contactUpdateDto)
    {
        if (contactUpdateDto == null)
        {
            throw new NullReferenceException();
        }

        var contact = GetContactById(id);
        if (contact == null) throw new NullReferenceException();
        contact.Firstname = contactUpdateDto.Firstname;
        contact.Lastname = contactUpdateDto.Lastname;
        contact.Phone = contactUpdateDto.Phone;

        return contact;

    }

    public void DeleteContactById(int id)
    {
        var endOfContext = _contacts.Count;
        _contacts.Remove(GetContactById(id));
        for (var i = id + 1; i <= endOfContext; i++)
        {
            UpdateId(i, i - 1);
        }

    }

    private void UpdateId(int oldId, int newId)
    {
        var contact = GetContactById(oldId);
        contact.Id = newId;
    }
    public void SaveChanges()
    {
        _manager.SaveContactsToFile(_contacts);
    }
}