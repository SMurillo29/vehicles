using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace vehicles.API.Data.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name = "Marca")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} Es obligatorio")]
        public string Description { get; set; }

        public ICollection<Vehicle> vehicles { get; set; }
    }
}
