using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budapest.API.Models
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto() { Id = 1, Name = "Virginópolis"},
                new CityDto() { Id = 2, Name = "Governador Valadares"},
            };
        }
    }
}
