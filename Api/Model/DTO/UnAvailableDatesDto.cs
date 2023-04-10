namespace Api.Model.DTO
{
   public class UnAvailableDatesDto
   {
      public List<DateTime> UnAvailableDates { get; set; }
      public UnAvailableDatesDto()
      {
         UnAvailableDates = new List<DateTime>();
      }
   }
}
