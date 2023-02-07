using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace BussinessLayer.BussinessUtil
{
  public  sealed class CountriesUtility
    {
        Entities Entities = null;
        public CountriesUtility()
        {
            Entities = new Entities();
        }
       
        public Dictionary<int,string> LoadCounties()
       {
            Dictionary<int,string> data = Entities.Countries.ToList().ToDictionary(x=>x.CountryId,y=>y.CountryName);
            return data;
        }
        public IEnumerable<string> LoadStates(int countryId)
        {
            var data = Entities.States.Where(x=>x.CountryId==countryId).Select(x=>x.StateName).ToList();
            return data.AsEnumerable();
        }
    }
}
