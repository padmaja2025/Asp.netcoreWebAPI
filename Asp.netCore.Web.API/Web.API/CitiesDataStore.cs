using Web.API.Model;

namespace Web.API
{
    public class CitiesDataStore
    {
        public List<CitiesDto> Cities { get; set; }

        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public CitiesDataStore() {

            Cities = new List<CitiesDto>()
            {
                new CitiesDto() { Id = 1, Name = "Newyork", Description="This is newyork"  },
                new CitiesDto() { Id = 2 , Name = "Oklahoma City", Description= "this is oklahoma city" },
                new CitiesDto() { Id = 3 , Name = "Los Angeles", Description= "this is los angeles" }
            };
        }


    }
}
