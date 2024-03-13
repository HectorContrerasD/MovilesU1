using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FakeStoreApiMoviles.Dtos;
using FakeStoreApiMoviles.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FakeStoreApiMoviles.ViewModels
{
    public class ProductosViewModel : INotifyPropertyChanged
    {

        private FakeStoreService api = new();
        public ProductoDto Producto { get; set; }= new ProductoDto();
        //public ProductoPostDto ProductoPost { get; set; } = new ProductoPostDto();
        public ProductoDto NuevoProducto { get; set; } = new();
        public ObservableCollection<ProductoDto> ProductoList { get; set; } 
        public List<Category> Categories { get; set; }
        public string Imagen {  get; set; }
   
        public Category Category { get; set; } = new();
        public ICommand AgregarProductoCommand { get; set; }    
        public ICommand EditarProductoCommand { get; set; }
        public ICommand EliminarProductoCommand { get; set; }
        public ICommand VerProductoCommand { get; set; }
        public int IdProducto { get; set; }
        public ProductosViewModel()
        {
            api = new();
            AgregarProductoCommand = new AsyncCommand(AgregarProducto);
            EditarProductoCommand = new AsyncCommand(EditarProducto);
            EliminarProductoCommand = new AsyncCommand(EliminarProducto);
            VerProductoCommand = new AsyncCommand<int>(VerProducto);
            MostrarProductos();
            Categorias();
            Actualizar();
        
        }

        private async Task VerProducto(int arg)
        {
            Producto = await api.GetProducto(arg);

            Category = Producto.category;
            IdProducto = Producto.id;
            Actualizar();
        }

        public async Task MostrarProductos()
        {
            ProductoList = new ObservableCollection<ProductoDto> (await api.GetProductos());
            Actualizar();
            
        }
        public async Task Categorias()
        {
            Categories = await api.GetCategories();
            Actualizar();
        }
       

        private async Task EliminarProducto()
        {
            if (Producto!=null)
            {
                await api.DeleteProduct(Producto, IdProducto);
                MostrarProductos();
            }
        }

        private async Task EditarProducto()
        {
            Producto.id = IdProducto;
            if (Producto != null)
            {
                
                Producto.categoryId = Category.id;
                await api.UpdateProduct(Producto);
                MostrarProductos();
            }
        }

        private async Task AgregarProducto()
        {
           
           
           
            if (Producto != null)
            {
                //NuevoProducto.images.Add(Imagen);

                Producto.categoryId = Category.id;
                
                ProductoList.Add(Producto);
                await api.CreateProduct(Producto);
                Actualizar();
                MostrarProductos();
            }
        }
        public void Actualizar()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
