namespace FakeStoreApiMoviles.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
	}
	private async void Agregar(object sender, EventArgs e)
	{
		await	Navigation.PushAsync(new AgregarProductoView());
	}
	private async void Editar(object sender,EventArgs e)
	{
		await Navigation.PushAsync(new EditarProductoView());
	}
	private async void Eliminar(object sender, EventArgs e)
	{
	 await  Navigation.PushAsync(new EliminarProductoView());
	}
}