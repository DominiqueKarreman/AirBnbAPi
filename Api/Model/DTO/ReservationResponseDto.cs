using System.Threading;

namespace Api.Model.DTO
{
    public class ReservationResponseDto
    {
        public string LocationName { get; set; }
        public string CustomerName { get; set; }
        public float Price { get; set; }
        public float? Discount { get; set; }
    }
}
