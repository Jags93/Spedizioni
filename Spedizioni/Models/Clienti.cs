using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spedizioni.Models
{
    public class Clienti
    {
        public int IdCliente { get; set; }

        [DisplayName("Nome Cliente")]
        [Required(ErrorMessage = "Il campo Nome Cliente è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il campo Nome Cliente deve essere di massimo 50 caratteri")]
        
        public string Nomimativo { get; set; }

        [DisplayName("Privato o Azienda")]
        public bool IsAzienda { get; set; }

        [DisplayName("Codice Fiscale")]
        [Remote("CheckCodiceFiscale", "Clienti", ErrorMessage = "Inserisci il codice fiscale valido")]
        public string CodiceFiscale { get; set; }

        [Remote("CheckPartitaIva", "Clienti", ErrorMessage = "Inserisci la partita iva valida")]
        public string PartitaIva { get; set; }
    }
}