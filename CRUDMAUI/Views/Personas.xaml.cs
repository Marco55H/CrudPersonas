namespace CRUDMAUI.Views;

public partial class Personas : ContentPage
{
	public Personas()
	{
		InitializeComponent();
	}
    private async void AgregarPersona(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Create");
    }

    private async void BorrarPersona(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Delete");
    }

    private async void EditarPersona(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Edit");
    }
}