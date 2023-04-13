using Api.Controllers;

namespace Api.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public Customer Customer { get; set; }
        public float Discount { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
