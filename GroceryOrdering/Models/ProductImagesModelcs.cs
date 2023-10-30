using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GroceryOrdering.Models
{
    public class ProductImagesModelcs
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Guid ProductId { get; set; }
        //public Product Product { get; set; }
    }
}
