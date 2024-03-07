using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Spedizioni.Models;
using System.Security.Policy;

namespace Spedizioni.Controllers
{
    public class ClientiController : Controller
    {
        // GET: Clienti
        public ActionResult NewCLient()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewClient([Bind(Include = "Nominativo, IsAzienda, CodiceFiscale, PartitaIva")]Clienti cliente)
        {
            if (ModelState.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["gls"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                    SqlCommand cmd;

                    if (cliente.IsAzienda)
                    {
                        cmd = new SqlCommand("insert into CLienti(Nominativo, IsAzienda, PartitaIva) values(@Nominativo, @IsAzienda, @PartitaIva)", connection);
                        cmd.Parameters.AddWithValue("@PArtitaIva", cliente.PartitaIva);
                    }
                    else
                    {
                        cmd = new SqlCommand("insert into CLienti(Nominativo, IsAzienda, CodiceFiscale) values(@Nominativo, @IsAzienda, @CodiceFiscale)", connection);
                        cmd.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
                    }
                    cmd.Parameters.AddWithValue("@Nominativo", cliente.Nomimativo);
                    cmd.Parameters.AddWithValue("@IsAzienda", cliente.IsAzienda);
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
                return RedirectToAction("ClienteSalvato");

            }

               return View(cliente);
        }

        public ActionResult ClienteSalvato()
        {
            TempData["Message"] = "Cliente Salvato";
            return View();
        }

    }
}