using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using InventoryManagementSystem.Model;

namespace InventoryManagementSystem.Gateway
{
    class ProductGateway
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection connection =new SqlConnection(connectionString);
        private SqlCommand command;

        public int saveProductGateway(Product product)
        {
            connection.Open();
            string query = "Insert Into Product (Name,CategoryId,Quantity) Values ('" + product.Name + "', '" + product.CategoryId + "','" + product.Quantity + "')";
            command = new SqlCommand(query,connection);
            int rowEffect = command.ExecuteNonQuery();
            connection.Close();

            return rowEffect;
        }

        public List<ProductWithCategory> GetProducts()
        {
            connection.Open();
            string query = "Select * from ProductWithCategory order by Name";
            command = new SqlCommand(query,connection);
            SqlDataReader reader = command.ExecuteReader();

            List<ProductWithCategory> products = new List<ProductWithCategory>();
            while (reader.Read())
            {
                ProductWithCategory aProduct = new ProductWithCategory();
                aProduct.Name = reader["Name"].ToString();
                aProduct.CategoryName =reader["CategoryName"].ToString();
                aProduct.Quantity = Convert.ToInt32(reader["Quantity"]);

                products.Add(aProduct);
            }
            reader.Close();
            connection.Close();

            return products;

        }

      
        
    }
}
