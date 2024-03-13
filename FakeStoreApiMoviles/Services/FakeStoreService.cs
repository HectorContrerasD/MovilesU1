using FakeStoreApiMoviles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;



namespace FakeStoreApiMoviles.Services
{
    public class FakeStoreService
    {
        public string url = "https://api.escuelajs.co/api/v1/";
        HttpClient client;
        public async Task<List<ProductoDto>> GetProductos()
        {
            client = new();
            var response = await client.GetAsync($"{url}products");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var productosdto = JsonSerializer.Deserialize<List<ProductoDto>>(json.ToString());
            return productosdto;
        }
        public async Task<ProductoDto> GetProducto(int id)
        {
            client = new();
            var response = await client.GetAsync($"{url}products/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var productodto = JsonSerializer.Deserialize<ProductoDto>(json.ToString());
            return productodto;

        }
        public async Task<List<Category>> GetCategories()
        {
            client = new();
            var response = await client.GetAsync("https://api.escuelajs.co/api/v1/categories");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var categoriydto = JsonSerializer.Deserialize<List<Category>>(json.ToString()) ;
            return categoriydto;
           
        }
        public async Task CreateProduct(ProductoDto dto)
        {

            client = new();
            var destino = new Uri($"{url}products/");
            var productodto = new ProductoDto()
            {
                title = dto.title,
                price = dto.price,
                description = dto.description,
                categoryId = dto.categoryId,
                images = new List<string>() { "https://i.imgur.com/cSytoSD.jpeg" }
            };
            var newpostjson = JsonSerializer.Serialize(productodto);
            var content = new StringContent(newpostjson, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(destino, content);
            if (result.IsSuccessStatusCode)
            {
                var resultcontent = await result.Content.ReadAsStringAsync();
            }
        }
        public async Task UpdateProduct(ProductoDto dto)
        {
            
            client = new();
            var destino = new Uri($"{url}products/{dto.id}");
            var productoputdto = new ProductoDto()
            {
                
                price = dto.price,
                description = dto.description,
                categoryId = dto.categoryId,
                images = new List<string>() { "https://i.imgur.com/cSytoSD.jpeg" },
                title = dto.title,
            };
            var newputson = JsonSerializer.Serialize(productoputdto);
            var content = new StringContent(newputson, Encoding.UTF8, "application/json");
            var result = await client.PutAsync(destino, content);
            if (result.IsSuccessStatusCode)
            {
                var resultcontent = await result.Content.ReadAsStringAsync();
            }
        }
        public async Task DeleteProduct( ProductoDto dto, int id)
        {
            client = new();
            var destino = new Uri($"{url}products/{id}");
            var result = await client.DeleteAsync(destino);
        }
    }
}
