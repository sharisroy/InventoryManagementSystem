using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Gateway;
using InventoryManagementSystem.Model;

namespace InventoryManagementSystem.Manager
{
    class CategoryManager
    {
        private CategoryGateway categoryGateway = new CategoryGateway();

        public List<Category> GetAllCategories()
        {
            return categoryGateway.GetCategories();
        } 
    }
}
