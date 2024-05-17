using System.ComponentModel.DataAnnotations;

namespace Actividad.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [Required(ErrorMessage = "Contenido requerido")]
        [StringLength(200, ErrorMessage = "El testo es demasiado largo")]
        public string? TextBody { get; set; }
        [Required(ErrorMessage = "Titulo requerido")]
        [StringLength(50, ErrorMessage = "El Titulo es demasiado largo")]
        public string? Title { get; set; }

      
        virtual public User User { get; set; }


        virtual public ICollection<Comment>? Comments { get; set; }







    }
}
