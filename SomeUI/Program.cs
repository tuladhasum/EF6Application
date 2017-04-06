using SamuraiApp.Domain;
using SamuraiApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeUI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {

            //InsertSamurai();
            //InsertMultipleSamurais();
            //SimpleSamuraiQuery();
            MoreQueries();
            Console.ReadLine();
        }

        private static void MoreQueries()
        {
            var name = "Sumit";
            //var samurais = _context.Samurais.Where(s => s.Name == name).ToList();
            // Will return an instance and not a list
            //var samurais = _context.Samurais.FirstOrDefault(s => s.Name == name);
            // Will search by Id or Key
            var samurais = _context.Samurais.Find(2);
        }

        private static void SimpleSamuraiQuery()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList();
                var query = context.Samurais;
                //var samuraisAgain = query.ToList();
                foreach (var samurai in samurais)
                {
                    Console.WriteLine(samurai.Name);
                }
            }
        }

        private static void InsertMultipleSamurais()
        {
            var samurai1 = new Samurai { Name = "Maggie" };
            var samurai2 = new Samurai { Name = "Sofi" };
            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(new List<Samurai> { samurai1, samurai2 });
                context.SaveChanges();
            }
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "Sumit" };
            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                //context.Add(samurai);
                context.SaveChanges();
            }
        }
    }
}
