using System.ComponentModel.DataAnnotations;
using System.Composition.Convention;

namespace Api.Model.DTO
{
    public class ReservationRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public float? Discount { get; set; }
      [Required]
      [DataType(DataType.EmailAddress)]
      [MinLength(2)]
      [EmailAddress]
      public string Email { get; set; }
      [Required]
      [MinLength(2)]
      public string FirstName { get; set; }
      [Required]
      [MinLength(2)]
      public string LastName { get; set; }
    }
}
