namespace CRUDMAUI.Views;

public partial class Create : ContentPage
{
	public Create()
	{
		InitializeComponent();
	}

    private async void VolverAPersonas(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Personas");
    }
}