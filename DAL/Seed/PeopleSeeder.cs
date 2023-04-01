using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seed
{
    public class PersonSeeder
    {
        private readonly ModelBuilder modelBuilder;
        public PersonSeeder(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            modelBuilder.Entity<Person>().HasData(
                new Person { id = 1, firstname = "Justin", lastname = "Boundy" }
            );

        }
    }
}
