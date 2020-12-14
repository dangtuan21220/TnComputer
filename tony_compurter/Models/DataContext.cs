using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using tony_compurter.Models;

namespace tony_compurter.Models
{
    public class DataContext:DbContext
    {
        //ham tao -> ghi de chuoi ket noi
        public DataContext() : base("name=connection")
        { }
        //khai bao cac class <=> anh xa
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Showroom> Showrooms { get; set; }
        public DbSet<Adv> Advs { get; set; }
        public DbSet<Mailing> Mailings { get; set; }
        public DbSet<BhOnline> BhOnlines { get; set; }
        public DbSet<Bhdn> Bhdns { get; set; }

    }
}