﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Configuration.Permissions
{
    public static class ShopPermissions
    {
        //Admin 
        public const int Admin = 9;

        //Product
        public const int ListProducts = 10;
        public const int SearchProducts = 11;
        public const int CreateProduct = 12;
        public const int EditProduct = 13;

        //ProductCategory
        public const int ListProductCategories = 20;
        public const int SearchProductCategories = 21;
        public const int CreateProductCategory = 22;
        public const int EditProductCategory = 23;

        

    }
}
