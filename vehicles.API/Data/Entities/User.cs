using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using vehicles.API.Common.Enums;

namespace vehicles.API.Data.Entities
{
    public class User :IdentityUser
    {
        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} Es obligatorio")]
        public string FirstName { get; set; }


        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} Es obligatorio")]
        public string LastName { get; set; }

        [Display(Name = "Tipo de documento")]
        [Required(ErrorMessage = "El campo {0} Es obligatorio")]
        public DocumentType DocumentType { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} Es obligatorio")]
        public string Document { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres.")]       
        public string Address { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44356/images/noimage.png"
            : $"https://vehicleszulu.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
