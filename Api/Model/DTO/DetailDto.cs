using System.Composition.Convention;

namespace Api.Model.DTO
{
    public class DetailDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int Rooms { get; set; }
        public int NumberOfGuests { get; set; }
        public float PricePerDay { get; set; }
        public int Type { get; set; }
        public int Features { get; set; }
        public List<Image> Images { get; set; }
        public LandlordDto Landlord { get; set; }

        public DetailDto()
        {
            this.Images = new List<Image>();
        }
    }
}
