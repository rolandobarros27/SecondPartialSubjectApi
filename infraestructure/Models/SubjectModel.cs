using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Models
{
    public class SubjectModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El tipo de documento es requerida")]
        [MinLength(3)]
        public string Document_Type { get; set; }

        [Required(ErrorMessage = "El documento es requerido")]
        public string document { get; set; }

        [Required(ErrorMessage = "El id de ciudad es requerida")]
        public string address { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [MinLength(3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        [MinLength(3)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "El status es requerido")]
        public bool Status { get; set; }
       
    }
}
