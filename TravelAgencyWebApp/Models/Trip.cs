using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TravelAgencyWebApp.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'URL dell'immagine è obbligatorio")]
        [Url(ErrorMessage = "L'Url inserito non è valido")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il titolo non può avere più di 100 caratteri")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Il campo descrizione è obbligatorio")]
        [Column(TypeName = "text")]
        public string Description { get; set; }
        public string Length { get; set; }
        public string Price { get; set; }


        public Trip()
        {

        }

        public Trip(string image, string title, string description, string length, string price)
        {
            this.Image = image;
            this.Title = title;
            this.Description = description;
            this.Length = length;
            this.Price = price;
        }


    }
}
