using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryApp.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Введите название книги")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена не может быть отрицательной")]
        public decimal Price { get; set; }
        public Genre Genre { get; set; }
        public int GenreID { get; set; }
    }
}
