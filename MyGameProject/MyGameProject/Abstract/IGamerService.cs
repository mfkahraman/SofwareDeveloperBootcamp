using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGameProject.Abstract;
using MyGameProject.Entities;

namespace MyGameProject.Abstract
{
    public interface IGamerService
    {
        public void Add(Gamer gamer);
        public void Update(Gamer gamer, string fn, string ln, string natid, DateTime dob);
        public void Remove(Gamer gamer);
    }
}
