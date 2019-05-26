using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Gateway;
using InventoryManagementSystem.Model;

namespace InventoryManagementSystem.Manager
{
    class ProductManager
    {
        ProductGateway aProductGateway = new ProductGateway();
        public string saveProductManger(Product product)
        {
            
            int rowEffect = aProductGateway.saveProductGateway(product);

            if (rowEffect > 0)
            {
                return "Save saccessfully";
            }
            return "save failed";

        }

        public List<ProductWithCategory> GetAllProducts()
        {
            return aProductGateway.GetProducts();
        }

       
    }
}
