using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Configuration.Provider;

namespace Spedizioni.Models
{
    public class CustRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string[] GetRolesForUser(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["gls"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string[] roles = new string[] { };
            try
            {
                connection.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select Ruolo from Utenti where Username = @Username", connection);
                cmd.Parameters.AddWithValue("@Username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    roles = new string[] { reader["Ruolo"].ToString() };
                }
            }
            catch (SqlException ex)
            {
                throw new ProviderException(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return roles;
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["gls"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            bool userIsInRole = false;
            try
            {
                connection.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select Ruolo from Utenti where Username = @Username", connection);
                cmd.Parameters.AddWithValue("@Username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userIsInRole = reader["Ruolo"].ToString() == roleName;
                }
            }
            catch (SqlException ex)
            {
                throw new ProviderException(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return userIsInRole;
        }
        public override string[] GetAllRoles()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["gls"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            List<string> roles = new List<string>();
            try
            {
                connection.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select distinct Ruolo from Utenti", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(reader["Ruolo"].ToString());
                }
            }
            catch (SqlException ex)
            {
                throw new ProviderException(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return roles.ToArray();
        }
        public override string[] GetUsersInRole(string roleName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["gls"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            List<string> users = new List<string>();
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select Username from Utenti where Ruolo = @Ruolo", connection);
                cmd.Parameters.AddWithValue("@Ruolo", roleName);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(reader["Username"].ToString());
                }
            }
            catch (SqlException ex)
            {
                throw new ProviderException(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return users.ToArray();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
    }
}