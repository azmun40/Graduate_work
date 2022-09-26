using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Internet_shop_app.Models;

namespace Internet_shop_app
{
    internal class AppDBContext : DbContext
    {
            public DbSet<Item> items { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                options.UseMySql("server=localhost;username=root;password=root;port=3306;database=internet_shop");
            }
        }

}

