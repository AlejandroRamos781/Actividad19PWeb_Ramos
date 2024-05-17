namespace Actividad.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string CommentBody {  get; set; }

        virtual public User? User { get; set; } 

        virtual public Post? Post { get; set; } 
    }
}
