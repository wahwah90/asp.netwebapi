﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace aspnetsportwebapi.Models
{
    public class ProductRepository : IRepository
    {
        private ProductDbContext context = new ProductDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
        public async Task<int> SaveProductAsync(Product product)
        {
            if (product.Id == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = await context.Products.FindAsync(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            return await context.SaveChangesAsync();
        }
        public async Task<Product> DeleteProductAsync(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }
        public IEnumerable<Order> Orders
        {
            get { return context.Orders.Include("Lines").Include("Lines.Product"); }
        }
        public async Task<int> SaveOrderAsync(Order order)
        {
            if (order.Id == 0)
            {
                context.Orders.Add(order);
            }
            return await context.SaveChangesAsync();
        }
        [Authorize(Roles = "Administrators")]
        public async Task<Order> DeleteOrderAsync(int orderID)
        {
            Order dbEntry = context.Orders.Find(orderID);

            if (dbEntry != null)
            {
                context.Orders.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }
    }
}