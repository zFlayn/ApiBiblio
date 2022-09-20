using System.ComponentModel.DataAnnotations;

namespace ApiBiblio.Entidades
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } 
        
        public virtual List<Autor> Datos { get; set; }

    }

    public class Autor
    {
        [Key]
        public int Id { get; set; } 

        public string Editorial { get; set; }

        public string Autorn { get; set; }

        public int Aid { get; set; }
    }
}
