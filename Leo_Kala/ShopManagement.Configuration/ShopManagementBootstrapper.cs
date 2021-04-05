﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EFCore.Context;
using ShopManagement.Infrastructure.EFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            //services.AddTransient<IProductApplication, ProductApplication>();
            //services.AddTransient<IProductRepository, ProductRepository>();

            //services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            //services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            //services.AddTransient<ISlideApplication, SlideApplication>();
            //services.AddTransient<ISlideRepository, SlideRepository>();

            //services.AddTransient<IOrderRepository, OrderRepository>();
            //services.AddTransient<IOrderApplication, OrderApplication>();

            //services.AddSingleton<ICartService, CartService>();

            //services.AddTransient<IShopInventoryAcl, ShopInventoryAcl>();
            //services.AddTransient<IShopAccountAcl, ShopAccountAcl>();

            //services.AddTransient<ISlideQuery, SlideQuery>();
            //services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            //services.AddTransient<IProductQuery, ProductQuery>();
            //services.AddTransient<ICartCalculatorService, CartCalculatorService>();

            //services.AddTransient<IPermissionExposer, ShopPermissionExposer>();
            services.AddDbContext<LeoContext>(x => x.UseSqlServer(connectionString));
        }
    }
}