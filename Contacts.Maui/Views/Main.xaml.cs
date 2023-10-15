using Contacts.Maui.Models;
using System.Collections.ObjectModel;
using Contact = Contacts.Maui.Models.RoverData;

namespace Contacts.Maui.Views;

public partial class Main : ContentPage
{
	public Main()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadContracts();
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(MoveRover));
    }

    private void LoadContracts()
    {
        var contacts = RoverOperations.Result;

        roverResult.Text = contacts;
    }
}