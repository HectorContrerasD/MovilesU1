namespace FakeStoreApiMoviles.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
	}
	private  void Agregar(object sender, EventArgs e)
	{
			Navigation.PushAsync(new AgregarProductoView());
	}
	private  void Editar(object sender,EventArgs e)
	{
		 Navigation.PushAsync(new EditarProductoView());
	}
	private  void Eliminar(object sender, EventArgs e)
	{
	 Navigation.PushAsync(new EliminarProductoView());
	}
}