using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.Models
{
    public class ProductBase
    {
       
        public string? Name { get; set; }
       
        public string? Description { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } = 0;
      
        public string? Image { get; set; }
     
        public int Quantity { get; set; }
      
        public Guid CategoryId { get; set; }

    }
}
