namespace Contacts.Maui.Views;

public partial class Edit : ContentPage
{
	public Edit()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}