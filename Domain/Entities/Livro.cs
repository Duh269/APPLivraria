using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{

    [Table("livro", Schema = "app_livraria")]
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
    }
}

