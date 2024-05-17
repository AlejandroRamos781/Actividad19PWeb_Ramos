using System.ComponentModel.DataAnnotations;

namespace Actividad.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "nombre requerido")]
        [StringLength(50, ErrorMessage = "El nombre es demasiado largo")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "email requerido")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [StringLength(50, ErrorMessage = "El email es demasiado largo")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Contraseña requerido")]
        [StringLength(50, ErrorMessage = "La contraseña es demasiado larga")]
        public string? Password { get; set; }

        virtual public ICollection<Post>? Posts { get; set; }

    }
}
