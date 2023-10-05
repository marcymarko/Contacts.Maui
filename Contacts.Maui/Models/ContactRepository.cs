
namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact{ ContactId = 1, Name = "Robik", Email = "mark" },
            new Contact{ ContactId = 2, Name = "Mark", Email = "robik" },
            new Contact{ ContactId = 3, Name = "John", Email = "scarlett" },
            new Contact{ ContactId = 4, Name = "Fil", Email = "john" },
            new Contact{ ContactId = 5, Name = "Scarlett", Email = "fil" },
        };

        public static List<Contact> GetContacts() => _contacts; 

        public static Contact GetContactById(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if(contact != null)
            {
                return new Contact
                {
                    ContactId = contactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Address = contact.Address,
                };
            }
            return null;
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Phone = contact.Phone;
            }
        }

        public static void AddContact(Contact contact)
        {
            var maxId = _contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            _contacts.Add(contact);
        }
    }
}
