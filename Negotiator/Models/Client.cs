using System.ComponentModel.DataAnnotations;

namespace Negotiator.Models
{
    public class Client
    {
       
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "Imię nie może być dłuższe niż 15 znaków")]
        [MinLength(3,ErrorMessage ="Imię musi posiadać minimum 3 znaki")]
        public  string ClientName { get; set; }
     


    }
}
