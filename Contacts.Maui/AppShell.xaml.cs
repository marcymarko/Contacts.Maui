using Contacts.Maui.Views;

namespace Contacts.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Main), typeof(Main));
            Routing.RegisterRoute(nameof(MoveRover), typeof(MoveRover));
        }
    }
}