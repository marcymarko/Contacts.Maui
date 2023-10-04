using System.Security.Cryptography.X509Certificates;

namespace Contacts.Maui.Views;

public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();

		List<Contact> contacts = new List<Contact>()
		{
			new Contact{ Name = "John Doe", Email = "mark" },
            new Contact{ Name = "John Doe", Email = "mark" },
            new Contact{ Name = "John Doe", Email = "mark" },
            new Contact{ Name = "John Doe", Email = "mark" },
            new Contact{ Name = "John Doe", Email = "mark" },
        };

		listContacts.ItemsSource = contacts;

    }

    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }

    }

}