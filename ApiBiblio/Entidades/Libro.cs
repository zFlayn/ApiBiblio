using System.ComponentModel.DataAnnotations;

namespace ApiBiblio.Entidades
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        [Required(ErrorMessage = "Se requiere llenar este campo")]

        public virtual List<Autor> Datos { get; set; }

    }

    public class Autor
    {
        [Key]
        public int Id { get; set; } 

        public string Editorial { get; set; }
        [Required (ErrorMessage = "Se requiere llenar este campo")]

        public string Autorn { get; set; }
        [Required(ErrorMessage = "Se requiere llenar este campo")]

        public int Aid { get; set; }
    }
}
