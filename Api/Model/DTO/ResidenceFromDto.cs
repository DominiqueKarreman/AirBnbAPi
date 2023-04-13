namespace Api.Model.DTO
{
   public class ResidenceFromDto
   {
      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }
      public List<DateTime> Dates { get; set; }

      public ResidenceFromDto()
      {
         Dates = new List<DateTime>();
      }

      public ResidenceFromDto(DateTime startDate, DateTime endDate)
      {
         StartDate = startDate;
         EndDate = endDate;
         Dates = new List<DateTime>();
      }

      public void GetDatesBetween()
      {
         var dates = new List<DateTime>();
         for (
             var date = this.StartDate.AddDays(1);
             date <= this.EndDate.AddDays(1);
             date = date.AddDays(1)
         )
         {
            dates.Add(date);
         }
         Dates = dates;
      }
   }
}
