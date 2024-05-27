using Friends_WPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friends_GUI
{
    public class DataContext :DbContext
    {
        public DbSet<Episode> episodes { get; set; }
        public DbSet<Season> seasons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=friends;Uid=root;Pwd=;", ServerVersion.AutoDetect("Server=localhost;Database=friends;Uid=root;Pwd=;"));
        }
    }
}
