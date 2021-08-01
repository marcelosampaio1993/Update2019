using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc2.Models;
using SalesWebMvc2.Models.Enums;
namespace SalesWebMvc2.Data
{
    public class SeedingService
    {
        private SalesWebMvc2Context _context;
        public SeedingService(SalesWebMvc2Context context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.Seller.Any())
            {
                return;//DB has been seeded  O banco de dados ja foi populado
            }
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 30), 3500.0, d2);
            Seller s3 = new Seller(3, "Alex Gray", "alex@gmail.com", new DateTime(1988, 3, 21), 2200.0, d1);
            Seller s4 = new Seller(4, "Martha Red", "marta@gmail.com", new DateTime(1993, 2, 21), 3000.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 6, 21), 4000.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "alex@gmail.com", new DateTime(1997, 2, 21), 3000.0, d2);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 9, 25), 11000.0, Models.Enums.SalesStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2020, 9, 25), 11000.0, Models.Enums.SalesStatus.Pending, s1);
            SalesRecord r3 = new SalesRecord(3, new DateTime(1993, 9, 25), 11000.0, Models.Enums.SalesStatus.Canceled, s1);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2000, 9, 25), 11000.0, Models.Enums.SalesStatus.Billed, s1);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4);

            _context.SaveChanges();
        }
    }
}
