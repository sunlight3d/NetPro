using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeStoreApi.Models
{
    public class Data:IData
    {
        public List<CakeStore> CakesList { get; set; }

        public List<CakeStore> CakesInitializeData()
        {
            CakesList = new List<CakeStore>()
            {
                new CakeStore(){Id = 1,CakeType = "BirthdayCake", Quantity = 50},//builder pattern
                new CakeStore(){Id = 2,CakeType = "StrawberryCake",Quantity = 48},
                new CakeStore(){Id = 3,CakeType = "CheesecakeCake",Quantity = 62},
                new CakeStore(){Id = 4, CakeType = "ChocolateCake", Quantity = 68}
            };

            return CakesList;
        }

        public CakeStore GetCakeById(int? id) => 
            id == null ? null : CakesList.SingleOrDefault(a => a.Id == id);//ternary
        
    }
}
