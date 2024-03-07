using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spedizioni.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace Spedizioni.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        [AllowAnonymous]
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Utente utente)
        {
            if (ModelState.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["gls"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand("select * from Utenti where Username = @Username and Pass = @Pass", connection);
                    cmd.Parameters.AddWithValue("@Username", utente.USername);
                    cmd.Parameters.AddWithValue("@Pass", utente.Pass);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        FormsAuthentication.SetAuthCookie(utente.USername, false);
                        return RedirectToAction("Index", "Home");


                    }
                    else
                    {
                        ViewBag.Error = "Username o Password errati";
                    }
                }
                catch (SqlException ex)
                {
                    ViewBag.Error = ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
            return View(utente);
        }   

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}