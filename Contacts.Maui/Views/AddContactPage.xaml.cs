using Contacts.Maui.Models;

namespace Contacts.Maui.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void contactCtrl_OnSubmit(object sender, EventArgs e)
    {
        RoverOperations.Calculate(new Models.RoverData
        {
            Bounds = contactCtrl.Bounds,
            MoveInstructions = contactCtrl.MoveInstructions,
            CurrentPosition = contactCtrl.CurrentPosition
        });

        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}