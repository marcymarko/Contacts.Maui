using Contacts.Maui.Models;

namespace Contacts.Maui.Views;

public partial class MoveRover : ContentPage
{
	public MoveRover()
	{
		InitializeComponent();
	}

    private void contactCtrl_OnSubmit(object sender, EventArgs e)
    {
        RoverOperations.Calculate(new Models.RoverData
        {
            Bounds = moveRoverCtrl.Bounds,
            MoveInstructions = moveRoverCtrl.MoveInstructions,
            CurrentPosition = moveRoverCtrl.CurrentPosition
        });

        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}