using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.Models
{
    public class UpdateProduct: ProductBase
    {
       

        public Guid Id { get; set; }
    }
}
