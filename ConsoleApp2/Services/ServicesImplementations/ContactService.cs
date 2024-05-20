using ConsoleApp2.Services.RepositoriesAbstractions;
using ConsoleApp2.Services.ServicesAbstractions;
using ConsoleApp2.Services.ServicesContracts;

namespace ConsoleApp2.Services.ServicesImplementations
{
    public class ContactService(IContactRepository repository) : IContactService
    {
        public void ShowContacts()
        {
            Console.WriteLine("Список контактов:");
            var contacts = repository.GetAllContacts();
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Id}. {contact.Lastname} {contact.Firstname}: {contact.Phone} ");
            }
        }

        public void CreateContact()
        {
            Console.WriteLine("Создание контакта. Введите фамилию контакта и нажмите Enter");
            var lastname = Console.ReadLine();
            Console.WriteLine("Создание контакта. Введите имя контакта и нажмите Enter");
            var firstname = Console.ReadLine();
            Console.WriteLine("Создание контакта. Введите номер телефона контакта и нажмите Enter");
            var phone = Console.ReadLine();
            var contactCreateDto = new ContactCreateDto()
            {
                Firstname = firstname,
                Lastname = lastname,
                Phone = phone
            };
            repository.CreateContact(contactCreateDto);
            repository.SaveChanges();
            Console.WriteLine("Контакт создан.");
        }

        public void UpdateContact()
        {
            Console.WriteLine("Для изменения контакта напишите Id контакта, который нужно мзменить");
            var id = int.Parse(Console.ReadLine());
            var oldContact = repository.GetContactById(id);
            Console.WriteLine($"Введите новую фамилию для {oldContact.Id}. {oldContact.Lastname}");
            var newLastname = Console.ReadLine();
            Console.WriteLine($"Введите новое имя для {oldContact.Id}. {oldContact.Firstname}");
            var newFirstname = Console.ReadLine();
            Console.WriteLine($"Введите новый номер телефона для {oldContact.Id}. {oldContact.Phone}");
            var newPhone = Console.ReadLine();
            var newContact = new ContactUpdateDto()
            {
                Firstname = newFirstname,
                Lastname = newLastname,
                Phone = newPhone
            };
            repository.UpdateContactById(id, newContact);
            repository.SaveChanges();
            Console.WriteLine("Контакт обновлен");
        }

        public void DeleteContact()
        {
            Console.WriteLine("Для удаления контакта напишите Id контакта, который нужно удалить");
            var id = int.Parse(Console.ReadLine());
            repository.DeleteContactById(id);
            repository.SaveChanges();
            Console.WriteLine("Контакт удален");
        }
    }
}
