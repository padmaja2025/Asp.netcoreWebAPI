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
                new CitiesDto() {
                    Id = 1,
                    Name = "Newyork",
                    Description="This is newyork",
                    PointsOfInterest = new List<PointofInterestDto>()
                    {
                        new PointofInterestDto()
                        { id = 1,
                          Name = "Central Park",
                          Description = "Central Park"

                        },
                          new PointofInterestDto()
                        { id = 2,
                          Name = "Central Park2",
                          Description = "Central Park2"

                        }
                    } 
                },
                new CitiesDto() {
                    Id = 2 ,
                    Name = "Oklahoma City", 
                    Description= "this is oklahoma city",
                    PointsOfInterest= new List<PointofInterestDto>()
                    {
                        new PointofInterestDto()
                        {
                            id =1,
                            Name= "Boat House",
                            Description = "Boat House"
                        },
                        new PointofInterestDto()
                        {
                            id =2,
                            Name= "Boat House2",
                            Description = "Boat House2"
                        }
                    }
                },
                new CitiesDto() { 
                    Id = 3 ,
                    Name = "Paris", 
                    Description= "this is los angeles" ,
                    PointsOfInterest = new List<PointofInterestDto>
                    {
                        new PointofInterestDto
                        {
                            id =1,
                            Name = "Eiffel Tower",
                            Description = "Eiffel Tower"
                        },
                         new PointofInterestDto
                        {
                            id =2,
                            Name = "The Louvre",
                            Description = "The Louvre"
                        }

                    }
                }
            };
        }


    }
}
