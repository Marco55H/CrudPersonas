using CRUDMAUI.Views;

namespace CRUDMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Create", typeof(Create));
            Routing.RegisterRoute("Delete", typeof(Delete));
            Routing.RegisterRoute("Edit", typeof(Edit));
            Routing.RegisterRoute("Personas", typeof(Personas));


        }
    }
}
