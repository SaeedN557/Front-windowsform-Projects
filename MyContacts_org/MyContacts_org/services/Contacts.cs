using MyContacts_org.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyContacts_org
{
    internal class Contacts : IContacts
    {
        private string connectionString = "Data Source=.;Initial Catalog=Contacts;Integrated Security=True";
        
        public bool delete(int contactId)
        {
            try
            {
                string query = "Delete from Contacts where ContactId=@ID";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactId);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool insert(string name, string family, string mobile, int age)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                
                string query = "Inset Into Contacts (Name,Family,Mobile,Age) values (@Name,@Family,@Mobile,@Age)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Age", age);
                connection.Open();
                command.ExecuteNonQuery();
                
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable search(string parameter)
        {
            string query = "Select 8 From Contacts Where Name like @parameter or Family like @parameter";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter","%"+parameter+"%");
            DataTable data=new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "select * from Contacts";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;

        }

        public DataTable Selector(int contactId)
        {
            string query = "select * from Contacts"+contactId;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool update(int contactId, string name, string family, string mobile, int age)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            try
            {
                string query = "Update Contacts Set Name=@Name,Family=@Family,Mobile=@Mobile,Age=@Age";
                SqlCommand command=new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@ID", contactId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Age", age);
                return true;
            }
            catch
            {
                return false;
            }
            finally { connection.Close(); }
        }

        public bool update(string text1, string text2, string text3, int v)
        {
            throw new NotImplementedException();
        }
    }
}
