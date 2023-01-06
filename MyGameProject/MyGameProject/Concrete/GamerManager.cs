using MyGameProject.Abstract;
using MyGameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameProject.Concrete
{
    public class GamerManager : IGamerService
    {
        public List<Gamer> gamers= new List<Gamer>();
        public void Add(Gamer gamer)
        {
            gamers.Add(gamer);
            Console.WriteLine("Gamer added to DB.");
        }

        public void Remove(Gamer gamer)
        {
            gamers.Remove(gamer);
            Console.WriteLine("Gamer removed from DB.");
        }

        public void Update(Gamer gamer,string fn, string ln, string natid, DateTime dob)
        {
            gamer.FirstName = fn;
            gamer.LastName = ln;
            gamer.NationalityId= natid;
            gamer.DateOfBirth= dob;
            Console.WriteLine("Gamer informations updated.");
        }
    }
}
