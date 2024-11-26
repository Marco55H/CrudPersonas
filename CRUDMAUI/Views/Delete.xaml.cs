namespace CRUDMAUI.Views;

public partial class Delete : ContentPage
{
	public Delete()
	{
		InitializeComponent();
	}

	private async void VolverAPersonas(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("Personas");
	}
}