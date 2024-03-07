using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spedizioni.Models
{
    public class Spedizioni
    {

        public int IdSpedizione { get; set; }
        public int IdCliente { get; set; }


        [DisplayName("Codice Tracciamento")]
        [Required(ErrorMessage = "Il campo Codice Tracciamento è obbligatorio")]
        [StringLength(12, MinimumLength =12,  ErrorMessage = "Il campo Codice Tracciamento deve essere di massimo 12 caratteri")]
        public string CodTracciamento { get; set; }



        [DisplayName("Data Spedizione")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Remote("CheckDataSpedizione", "Spedizioni", ErrorMessage = "Inserisci la data di spedizione valida")]
        
        public DateTime DataSpedizione { get; set; }


        [DisplayName("Peso Spedizione")]
        [Required(ErrorMessage = "Il campo Peso Spedizione è obbligatorio")]
        public decimal PesoSpedizione { get; set; }


        [DisplayName("Città Destinazione")]
        [Required(ErrorMessage = "Il campo Città Destinazione è obbligatorio")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "Il campo Città Destinazione deve essere di massimo 50 caratteri")]
        public string CittaDestinazione { get; set; }



        [DisplayName("Indirizzo Destinazione")]
        [Required(ErrorMessage = "Il campo Indirizzo Destinazione è obbligatorio")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "Il campo Indirizzo Destinazione deve essere di massimo 50 caratteri")]
        public string IndirizzoDestinazione { get; set; }


        [DisplayName("Costo Spedizione")]
        [Required(ErrorMessage = "Il campo Costo Spedizione è obbligatorio")]

        public string CostoSpedizione { get; set; }


        [DisplayName("Data Consegna")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Remote("CheckDataConsegna", "Spedizioni", ErrorMessage = "Inserisci la data di consegna valida")]
        public DateTime DataConsegna { get; set; }
      
    }
}