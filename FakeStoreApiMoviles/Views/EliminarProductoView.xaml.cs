namespace FakeStoreApiMoviles.Views;

public partial class EliminarProductoView : ContentPage
{
	public EliminarProductoView()
	{
		InitializeComponent();
	}
    private void Regresar(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainView());
    }
}