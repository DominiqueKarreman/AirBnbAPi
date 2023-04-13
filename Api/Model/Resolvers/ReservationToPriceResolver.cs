using Api.Model.DTO;
using AutoMapper;

namespace Api.Model.Resolvers
{
    public class ReservationToPriceResolver
        : IValueResolver<Reservation, ReservationResponseDto, float>
    {
        public float Resolve(
            Reservation source,
            ReservationResponseDto destination,
            float destMember,
            ResolutionContext context
        )
        {
            TimeSpan timeBetweenStartEnd = source.EndDate - source.StartDate;
            int daysBetween = timeBetweenStartEnd.Days;
            float price = source.Location.PricePerDay * daysBetween;
            return price;
        }
    }
}
