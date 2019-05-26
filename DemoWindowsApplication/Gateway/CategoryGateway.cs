using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Model;

namespace InventoryManagementSystem.Gateway
{
    class CategoryGateway
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        private SqlCommand command;
        private SqlDataReader reader;


        public List <Category> GetCategories()
        {
            string query = "Select * From Category";
            connection.Open();
            command= new SqlCommand(query,connection);
            reader = command.ExecuteReader();

            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
                category.IdCategory = (int)reader["IdCategory"];
                category.NameCategory = reader["CategoryName"].ToString();

                categories.Add(category);
            }
            reader.Close();
            connection.Close();
            return categories;

        }
    }
}
