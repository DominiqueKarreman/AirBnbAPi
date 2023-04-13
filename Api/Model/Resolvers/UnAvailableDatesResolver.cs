using Api.Model.DTO;
using AutoMapper;

namespace Api.Model.Resolvers
{
   public class UnAvailableDatesResolver : IValueResolver<List<Reservation>, UnAvailableDatesDto, List<DateTime>>
   {
      public List<DateTime> Resolve(List<Reservation> source, UnAvailableDatesDto destination, List<DateTime> destMember, ResolutionContext context)
      {
         var unAvailableDates = new List<DateTime>();

         foreach (var reservation in source)
         {
            var residence = new ResidenceFromDto(reservation.StartDate, reservation.EndDate);
            var dates = new List<DateTime>();
            for (
                var date = residence.StartDate.AddDays(1);
                date <= residence.EndDate.AddDays(1);
                date = date.AddDays(1)
            )
            {
               dates.Add(date);
            }
            residence.Dates = dates;
            unAvailableDates.AddRange(residence.Dates.Select(date => date.Date.AddHours(22)));
         }

         return unAvailableDates;
      }
   }


}
