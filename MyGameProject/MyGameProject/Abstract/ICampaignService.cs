using MyGameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameProject.Abstract
{
    public interface ICampaignService
    {
        public void Add(Campaign campaign);
        public void Remove(Campaign campaign);
        public void Update(Campaign campaign);
    }
}
