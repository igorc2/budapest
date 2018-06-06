using Budapest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budapest.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto() {
                    Id = 1,
                    Name = "Virginópolis",
                    Description = "Cidade das vierge",
                    PointsOfInterest = new List<PointOfInterestDto>
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Capelinha",
                            Description = "Maior escadaria",
                        }
                    }
                },
                new CityDto() {
                    Id = 2,
                    Name = "Governador Valadares",
                    Description = "Quente",
                    PointsOfInterest = new List<PointOfInterestDto>
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Ibituruna",
                            Description = "Morrão",
                        }
                    }
                },
            };
        }
    }
}
