namespace FakeStoreApiMoviles.Views;

public partial class AgregarProductoView : ContentPage
{
	public AgregarProductoView()
	{
		InitializeComponent();
	}
	private void Regresar(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MainView());
	}
}