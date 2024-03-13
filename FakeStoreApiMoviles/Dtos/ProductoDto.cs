using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStoreApiMoviles.Dtos
{
    public class ProductoDto
    {
        public int id { get; set; }
        public string title { get; set; } = null!;
        public decimal price { get; set; }
        public string description { get; set; } = null!;
        public Category category { get; set; } = new();
        public int categoryId { get; set; }
        public List<string>? images { get; set; }
    }
    public class Category
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? image { get; set; }
    }
}
