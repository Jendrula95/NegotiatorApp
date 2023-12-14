using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Negotiator.Models
{
    public class Products
    {
     
        public int Id { get; set; }
      [MaxLength(25, ErrorMessage ="Nazwa produktu nie może być dłuższa niż 25 znaków")]
        public string Name { get; set; }
        [MaxLength(250, ErrorMessage = "Opis produktu nie może być dłuższy niż 250 znaków")]
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Cena nie może być mniejsza niż 0.")]
        public decimal BasedPrice { get; set; }


        public string Category { get; set; }
        public Products()
        {

        }
        public Products (Products obj)
        {
            this.Id = obj.Id;
            this.Name = obj.Name;
            this.Description = obj.Description;
            this.BasedPrice = obj.BasedPrice;
            this.Category = obj.Category;
        }

    }
}
