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
        static void Main(string[] args)
        {
            //InsertSamurai();
            //InsertMultipleSamurais();
            SimpleSamuraiQuery();
            Console.ReadLine();
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
