using MyGameProject.Concrete;
using MyGameProject.Entities;
using System.Collections.Generic;

GamerManager gM1= new GamerManager();

Gamer furkan = new Gamer
{ Id = 1, FirstName = "Furkan", LastName = "Kahraman", NationalityId = "2306742910", DateOfBirth = new DateTime(1992, 01, 01) };

gM1.Add(furkan);



foreach (gM1.gamers)
{
    Console.WriteLine(gM1.gamers.firstName);
}