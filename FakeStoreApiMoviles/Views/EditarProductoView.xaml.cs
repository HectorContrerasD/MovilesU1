namespace FakeStoreApiMoviles.Views;

public partial class EditarProductoView : ContentPage
{
	public EditarProductoView()
	{
		InitializeComponent();
	}

    private void Regresar(object sender, EventArgs e)
    {
		Navigation.PushAsync(new MainView());
    }
}