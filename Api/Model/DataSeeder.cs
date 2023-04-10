using Api.Data;
using Microsoft.CodeAnalysis;

namespace Api.Model
{
   public class DataSeeder
   {
      private readonly ApiContext _context;

      public DataSeeder(ApiContext context)
      {
         this._context = context;
      }

      public void Seed()
      {
         if (!_context.Customer.Any())
         {
            Image landlordAvatar = new Image()
            {
               Url = "https://media.nhnieuws.nl/images/326179.e418077.jpg?width=1000&ratio=16:9&quality=70",
               IsCover = false,
            };
           
            _context.SaveChanges();
            Landlord landlord = new Landlord()
            {
               FirstName = "Dominique",
               LastName = "Karreman",
               Age = 18,
               Avatar = landlordAvatar,
               Locations = new List<Location>(),
               AvatarId = landlordAvatar.Id
            };

            _context.SaveChanges();

            Location boerenhoeve = new Location()
            {
               Title = "Boerenhoeve",
               SubTitle = "Lekker veel ruimte",
               Description = "De camping ligt verscholen achter de boerderij in de polder. Op fietsafstand (5 minuten) liggen het dorpje Nieuwvliet, de zee, het strand, het bos van Erasmus en het natuurgebied de Knokkert.",
               Rooms = 5,
               Landlord = landlord,
               LandlordId = landlord.Id,
               NumberOfGuests = 12,
               PricePerDay = 300,
               Type = (LocationType)1,
               Features = Features.Smoking | Features.Breakfast,

            };
            Location frankie = new Location()
            {

               Title = "Frankie's Penthouse",
               SubTitle = "Te gek uitzicht",
               Description = "Nee, dit puike penthouse dat al jaren te koop stond en nu is verkocht, is niet de duurste woning van ons land. Bij lange na niet. Wel is de meer dan €30.000 per vierkante meter woonruimte een record in ons land.",
               Rooms = 2,
               NumberOfGuests = 4,
               Landlord = landlord,
               LandlordId = landlord.Id,
               PricePerDay = 400,
               Type = (LocationType)0,
               Features = Features.Bath | Features.Wifi

            };
            Image img2 = new Image()
            {
               Url = "https://media.cntraveler.com/photos/61a60b14e663d9fce4b711c1/1:1/w_800,h_801,c_limit/Airbnb%2039271504.jpg",
               IsCover = true,
               LocationId = frankie.Id,
            };
            Image img3 = new Image()
            {
               Url = "https://www.mashvisor.com/blog/wp-content/uploads/2019/12/House-Hacking-with-Airbnb-How-to-Live-for-Free.jpg",
               IsCover = true,
               LocationId = boerenhoeve.Id
            };
            boerenhoeve.Images.Add(img2);
            frankie.Images.Add(img3);


            var Locations = new List<Location>()
                {       
                       boerenhoeve,
                       frankie,
                     
                };

            _context.Location.AddRange(Locations);
            _context.SaveChanges();

            var customer = new Customer()
            {
               FirstName = "Dominique",
               LastName = "Karreman",
               Email = "Domikar2010@hotmail.com",

            };
            _context.Customer.Add(customer);
            _context.SaveChanges();
            var reservation = new Reservation()
            {
               Location = boerenhoeve,
               LocationId = boerenhoeve.Id,
               Discount = 20.00F,
               StartDate = new DateTime(2023, 04, 20),
               EndDate = new DateTime(2024, 04, 25),
               CustomerId = customer.Id,
               Customer = customer,
            };
            customer.Reservations.Add(reservation);
            _context.SaveChanges();
         }
      }
   }
}
