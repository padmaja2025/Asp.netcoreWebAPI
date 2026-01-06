namespace Web.API.Model
{
    public class CitiesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumofPointofInterests
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }

        public ICollection<PointofInterestDto> PointsOfInterest { get; set; } = new List<PointofInterestDto>();

       

    }
}
