using ConsoleApp2.Domain;
using ConsoleApp2.Services.ServicesContracts;

namespace ConsoleApp2.Services.RepositoriesAbstractions;

public interface IContactRepository
{
    public void CreateContact(ContactCreateDto contactCreateDto);
    public IEnumerable<Contact> GetAllContacts();
    public Contact GetContactById(int id);
    public Contact UpdateContactById(int id, ContactUpdateDto contactUpdateDto);
    public void DeleteContactById(int id);
    public void SaveChanges();
}