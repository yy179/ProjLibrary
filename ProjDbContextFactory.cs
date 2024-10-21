using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ClassLibrary;

namespace ClassLibrary
{
    public class ProjectDbContextFactory : IDesignTimeDbContextFactory<ProjDbContext>
    {
        public ProjDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\ProjDb.mdf;Integrated Security=True;Connect Timeout=30");

            return new ProjDbContext(optionsBuilder.Options);
        }
    }
}