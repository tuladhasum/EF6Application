using SamuraiApp.Domain;
using SamuraiApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            //MoreQueries();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurais();
            //MultipleOperations();
            //QueryAndUpdateSamuraiDisconnected();
            //AddSomeMoreSamurais();
            //DeleteWhileTracked();
            //DeleteMany();
            //DeleteWhileNotTracked();
            Console.ReadLine();
        }

        private static void DeleteWhileNotTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Heihachi");
            using (var contextNewAppInstance = new SamuraiContext())
            {
                contextNewAppInstance.Samurais.Remove(samurai);
                //contextNewAppInstance.Entry(samurai).State = EntityState.Deleted;
                contextNewAppInstance.SaveChanges();
            }
        }

        private static void DeleteMany()
        {
            var samurais = _context.Samurais.Where(s => s.Name.Contains("0"));
            _context.Samurais.RemoveRange(samurais);
            // alternate: _context.RemoveRange(samurais);
            _context.SaveChanges();
        }

        private static void DeleteWhileTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Kambei Shimada");
            _context.Samurais.Remove(samurai);
            //alternates:
            //_context.Remove(samurai);
            //_context.Entry(samurai).State = EntityState.Deleted;
            //_context.Samurais.Remove(_context.Samurais.Find(1));
            _context.SaveChanges();
        }

        private static void AddSomeMoreSamurais()
        {
            _context.AddRange(
                new Samurai { Name = "Kambei Shimada" },
                new Samurai { Name = "James Smith" },
                new Samurai { Name = "Jared Kushner" },
                new Samurai { Name = "Steph McMan" },
                new Samurai { Name = "Nathan Nill" },
                new Samurai { Name = "Randy Orton" },
                new Samurai { Name = "Kevin O'leary" }
                );
            _context.SaveChanges();
        }

        private static void QueryAndUpdateSamuraiDisconnected()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Jared");
            samurai.Name += "San";
            using (var contextNewAppInstance = new SamuraiContext())
            {
                contextNewAppInstance.Samurais.Update(samurai);
                contextNewAppInstance.SaveChanges();
            }
        }

        private static void MultipleOperations()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.Samurais.Add(new Samurai { Name = "Jared" });
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = _context.Samurais.ToList();
            samurais.ForEach(s => s.Name += "San");
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.SaveChanges();
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
