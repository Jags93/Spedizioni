using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spedizioni.Models
{
    public class Utente
    {
        public int IdUtente { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Il campo Nome Utente è obbligatorio")]
        [StringLength(50, MinimumLength =8, ErrorMessage = "Il campo Nome Utente deve essere di massimo 50 caratteri")]
        public string USername { get; set; }



        [DisplayName("Password")]
        [Required(ErrorMessage = "Il campo Password è obbligatorio")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Il campo Password deve essere di massimo 20 caratteri")]
        public string Pass { get; set; }
        public string Ruolo { get; set; }
    }
}