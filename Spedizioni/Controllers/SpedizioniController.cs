using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Spedizioni.Models;
using System.Runtime.Remoting.Messaging;

namespace Spedizioni.Controllers
{
    public class SpedizioniController : Controller
    {
        // GET: Spedizioni
        public ActionResult NewSpedi ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult NewSpedi([Bind(Include = "IdCliente, Data, Destinatario, Indirizzo, Citta, Provincia, Cap, Peso, Volume, Valore, Assicurazione, Tipo, Note")]Spedizioni spedizione)
        {
            if (ModelState.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["gls"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("insert into Spedizioni(Idcliente, CodTracciamento, DataSpedizione, PesoSpedizione, CittaDestinazione, IndirizzoDestinazione, CostoSpedizione, DataConsegna) values(@IdCliente, @CodTracciamento, @DataSpedizione, @PesoSpedizione, @CittaDestinazione, @IndirizzoDestinazione, @CostoSpedizione, @DataConsegna)", connection);
                    cmd.Parameters.AddWithValue("@IdCliente", spedizione.IdCliente);
                    cmd.Parameters.AddWithValue("@CodTracciamento", spedizione.CodTracciamento);
                    cmd.Parameters.AddWithValue("@DataSpedizione", spedizione.DataSpedizione);
                    cmd.Parameters.AddWithValue("@PesoSpedizione", spedizione.PesoSpedizione);
                    cmd.Parameters.AddWithValue("@CittaDestinazione", spedizione.CittaDestinazione);
                    cmd.Parameters.AddWithValue("@IndirizzoDestinazione", spedizione.IndirizzoDestinazione);
                    cmd.Parameters.AddWithValue("@CostoSpedizione", spedizione.CostoSpedizione);
                    cmd.Parameters.AddWithValue("@DataConsegna", spedizione.DataConsegna);
                    cmd.ExecuteNonQuery();
                    
                   
                   
                }
                catch (SqlException ex)
                {
                    ViewBag.Error = ex.Message;
                }
                finally
                {
                    connection.Close();
                }
                return RedirectToAction("SpedizioneSalvata");
            }
            return View(spedizione);
        }
        public ActionResult SpedizioneSalvata()
        {
            TempData["Message"] = "Spedizione Salvata";
            return View();
        }
        [HttpPost]
        
        public JsonResult CheckDataSpedizione(DateTime DataSpedizione)
        {
            if (DataSpedizione < DateTime.Now)
            {
                return Json("La data di spedizione non può essere antecedente a quella odierna", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
       

        
    }
}