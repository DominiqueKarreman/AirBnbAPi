using Api.Data;

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
               Url = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.houseplans.com%2Fblog%2Fbuild-an-airbnb-home-its-not-just-for-millennials&psig=AOvVaw0jAjrxWFMRdiTK2lTyER_l&ust=1680346481273000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCKDXxcuAhv4CFQAAAAAdAAAAABAE",
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
               Features = 0,

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
               Features = 0,
            };
            Image img2 = new Image()
            {
               Url = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.housebeautiful.com%2Flifestyle%2Fg21600970%2Fluxury-retreats-airbnb%2F&psig=AOvVaw0jAjrxWFMRdiTK2lTyER_l&ust=1680346481273000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCKDXxcuAhv4CFQAAAAAdAAAAABAJ",
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
         }
      }
   }
}
