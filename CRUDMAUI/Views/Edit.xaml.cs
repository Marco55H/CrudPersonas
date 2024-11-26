namespace CRUDMAUI.Views;

public partial class Edit : ContentPage
{
	public Edit()
	{
		InitializeComponent();
	}

	private async void VolverAPersonas(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("Personas");
	}
}