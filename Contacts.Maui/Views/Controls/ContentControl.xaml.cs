namespace Contacts.Maui.Views.Controls;

public partial class ContentControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSubmit;
    public event EventHandler<EventArgs> OnCancel;


    public ContentControl()
    {
        InitializeComponent();
    }

    public string Bounds
    {
        get
        {
            return entryBounds.Text;
        }

        set
        {
            entryBounds.Text = value;
        }
    }

    public string MoveInstructions
    {
        get
        {
            return entryMoveInstructions.Text;
        }

        set
        {
            entryMoveInstructions.Text = value;
        }
    }

    public string CurrentPosition
    {
        get
        {
            return entryPosition.Text;
        }

        set
        {
            entryPosition.Text = value; 
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }

    private void btnSubmit_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Bounds are required.");
            return;
        }

        if(positionValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Current position and heading required.");
            return;
        }

        if (moveInstructionsValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Move Instructions required.");
            return;
        }

        OnSubmit?.Invoke(sender, e);
    }   
}