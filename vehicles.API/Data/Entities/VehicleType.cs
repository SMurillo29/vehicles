using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vehicles.API.Data.Entities
{
    public class VehicleType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de vehículo")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} Es obligatorio")]
        public string Description { get; set; }

        public ICollection<Vehicle> vehicles { get; set; }

        [Display(Name = "Usuario")]        
        [Required(ErrorMessage = "El campo {0} Es obligatorio")]
        public User Usuario { get; set; }
    }
}
