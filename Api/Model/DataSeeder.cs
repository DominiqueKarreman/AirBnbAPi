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
            Image landlordAvatar2 = new()
            {
               Url = "https://www.female-founders.org/wp-content/uploads/2022/10/Female_Founders_20222462-scaled-e1665747943211.jpg",
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
            Landlord landlord2 = new Landlord()
            {
               FirstName = "Jane",
               LastName = "Doe",
               Age = 38,
               Avatar = landlordAvatar2,
               Locations = new List<Location>(),
               AvatarId = landlordAvatar2.Id
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

            Location location1 = new Location()
            {
               Title = "Het Havenhuis",
               SubTitle = "Gezellig appartement in de haven",
               Description = "Dit gezellige appartement ligt in de haven van Rotterdam en biedt een prachtig uitzicht over de Maas. Het appartement heeft twee kamers en is geschikt voor vier personen. De prijs per dag is €350.",
               Rooms = 2,
               NumberOfGuests = 4,
               Landlord = landlord,
               LandlordId = landlord.Id,
               PricePerDay = 350,
               Type = (LocationType)0,
               Features = Features.Bath | Features.Wifi
            };
            Location location2 = new Location()
            {
               Title = "De Boerderij",
               SubTitle = "Logeren op de boerderij",
               Description = "Breng je vakantie door op de boerderij! Onze boerderij is gelegen in het prachtige landschap van de Veluwe. Het huis heeft vijf kamers en biedt plaats aan twaalf personen. De prijs per dag is €300.",
               Rooms = 5,
               NumberOfGuests = 12,
               Landlord = landlord2,
               LandlordId = landlord2.Id,
               PricePerDay = 300,
               Type = (LocationType)1,
               Features = Features.Smoking | Features.Breakfast
            };
            Location location3 = new Location()
            {
               Title = "De Vuurtoren",
               SubTitle = "Unieke locatie aan de kust",
               Description = "Kom tot rust in deze unieke vuurtoren aan de kust van Texel. De vuurtoren is omgebouwd tot een gezellig vakantiehuis en biedt een adembenemend uitzicht over de zee. Het huis heeft één kamer en is geschikt voor twee personen. De prijs per dag is €200.",
               Rooms = 1,
               NumberOfGuests = 2,
               Landlord = landlord,
               LandlordId = landlord.Id,
               PricePerDay = 200,
               Type = (LocationType)0,
               Features = Features.Bath | Features.Wifi
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
            Location deHoutenChalet = new Location()
            {
               Title = "De Houten Chalet",
               SubTitle = "Knus en gezellig verblijf",
               Description = "Een heerlijke plek om tot rust te komen in de natuur. Deze gezellige houten chalet biedt alles wat je nodig hebt voor een ontspannen verblijf. Met een prachtig uitzicht op de omringende bossen en bergen, is dit de ideale plek voor natuurliefhebbers. De chalet heeft twee slaapkamers, een open keuken en een woonkamer met een houtkachel. Buiten vind je een ruim terras en een hot tub waar je kunt ontspannen onder de sterrenhemel.",
               Rooms = 2,
               NumberOfGuests = 4,
               Landlord = landlord2,
               LandlordId = landlord2.Id,
               PricePerDay = 200,
               Type = (LocationType)2,
               Features = Features.PetsAllowed | Features.Wifi | Features.Bath
            };
            Location hetZonnigeAppartement = new Location()
            {
               Title = "Het Zonnige Appartement",
               SubTitle = "Midden in de stad",
               Description = "Dit prachtige appartement is gelegen in het hart van de stad en biedt een spectaculair uitzicht op de skyline. Met veel natuurlijk licht en moderne inrichting, is dit de perfecte uitvalsbasis voor een stedentrip. Het appartement heeft twee slaapkamers, een volledig uitgeruste keuken en een ruime woonkamer met grote ramen. Geniet van het zonnetje op het balkon met uitzicht op de stad.",
               Rooms = 2,
               NumberOfGuests = 4,
               Landlord = landlord,
               LandlordId = landlord.Id,
               PricePerDay = 150,
               Type = (LocationType)0,
               Features = Features.Wifi | Features.TV | Features.Breakfast
            };
            Location hetLuxeStrandhuis = new Location()
            {
               Title = "Het Luxe Strandhuis",
               SubTitle = "Geniet van de zon, zee en strand",
               Description = "Dit prachtige strandhuis biedt alles wat je nodig hebt voor een heerlijke vakantie aan zee. Met uitzicht op de oceaan en het strand voor de deur, hoef je nergens anders naartoe. Het huis heeft drie slaapkamers, een moderne keuken en een ruime woonkamer met grote ramen. Buiten vind je een groot terras met ligstoelen en een barbecue. Na een dagje op het strand, kun je ontspannen in de hot tub met uitzicht op de zonsondergang.",
               Rooms = 3,
               NumberOfGuests = 6,
               Landlord = landlord2,
               LandlordId = landlord2.Id,
               PricePerDay = 350,
               Type = (LocationType)5,
               Features = Features.Smoking | Features.Wifi | Features.Bath
            };
            Image img2 = new Image()
            {
               Url = "https://media.cntraveler.com/photos/61a60b14e663d9fce4b711c1/1:1/w_800,h_801,c_limit/Airbnb%2039271504.jpg",
               IsCover = true,
               LocationId = frankie.Id,
            };
    
            var boerenhoeveImages = new List<Image>()
            {
               new Image()
               {
                  Url = "https://a0.muscache.com/im/pictures/miso/Hosting-50201747/original/7198cd4e-4faa-4ae1-9483-4608c9bae082.jpeg?im_w=1200",
                  IsCover = true,
                  LocationId = boerenhoeve.Id
               },
               new Image()
               {
                  Url = "https://a0.muscache.com/im/pictures/miso/Hosting-50201747/original/987686dd-5d4d-4187-82a6-4c8090b1b076.jpeg?im_w=720",
                  IsCover = false,
                  LocationId = boerenhoeve.Id
               },
               new Image()
               {
                  Url = "https://a0.muscache.com/im/pictures/miso/Hosting-50201747/original/54cf18da-1619-495e-8fb6-bec8bf625bae.jpeg?im_w=720",
                  IsCover = false,
                  LocationId = boerenhoeve.Id
               },
               new Image()
               {
                  Url = "https://a0.muscache.com/im/pictures/miso/Hosting-50201747/original/63ca19c8-ebfe-4cce-9647-74f54c0efade.jpeg?im_w=720",
                  IsCover = false,
                  LocationId = boerenhoeve.Id
               },
                 new Image()
               {
                  Url = "https://a0.muscache.com/im/pictures/miso/Hosting-50201747/original/c8282aeb-f7d6-4172-9042-1444a89bf66a.jpeg?im_w=720",
                  IsCover = false,
                  LocationId = boerenhoeve.Id
               },

            };

            boerenhoeve.Images.AddRange(boerenhoeveImages);
            var frankieImages = new List<Image>()
            {
               new Image()
               {
                  Url = "https://a0.muscache.com/im/pictures/miso/Hosting-775413830073194061/original/78be0e05-856b-4bb3-84e8-285abedbadef.jpeg?im_w=1200",
                  IsCover = true,
                  LocationId = frankie.Id
               },
               new Image()
               {
                  Url = "https://a0.muscache.com/im/pictures/miso/Hosting-775413830073194061/original/512d58cc-cd93-4c30-a16c-0162ed93a76e.jpeg?im_w=720",
                  IsCover = false,
                  LocationId = frankie.Id
               },
               new Image()
               {
                  Url = "https://a0.muscache.com/im/pictures/miso/Hosting-775413830073194061/original/dae86f3b-7c33-4d85-bc33-5823e30e251c.jpeg?im_w=720",
                  IsCover = false,
                  LocationId = frankie.Id
               },
               new Image()
               {
                  Url = "https://a0.muscache.com/im/pictures/miso/Hosting-775413830073194061/original/f08ed41f-127d-49b7-9e7b-a07c894dbd51.jpeg?im_w=720",
                  IsCover = false,
                  LocationId = frankie.Id
               },
               new Image()
               {
                  Url = "https://a0.muscache.com/im/pictures/miso/Hosting-775413830073194061/original/45133f4b-2433-4821-83df-c12a11576eb8.jpeg?im_w=720",
                  IsCover = false,
                  LocationId = frankie.Id
               },
              
            };
            frankie.Images.AddRange(frankieImages);
            var location1Images = new List<Image>()
            {
            new Image()
            {
                  Url = "https://a0.muscache.com/im/pictures/prohost-api/Hosting-599709750607614603/original/0e1264aa-f0f5-4edb-8b16-41ed4d77e0b7.jpeg?im_w=1200",
                  IsCover = true,
                  LocationId = location1.Id
            },
            new Image()
            {
               Url = "https://a0.muscache.com/im/pictures/prohost-api/Hosting-599709750607614603/original/651374b5-17f4-4f66-8104-fee2e73d3b46.jpeg?im_w=720",
               IsCover = false,
               LocationId = location1.Id
            },
            new Image()
            {
               Url = "https://a0.muscache.com/im/pictures/prohost-api/Hosting-599709750607614603/original/54635252-24c8-4b56-bf1e-537d1e690955.jpeg?im_w=720",
               IsCover = false,
               LocationId = location1.Id
            },
            new Image()
            {
               Url = "https://a0.muscache.com/im/pictures/prohost-api/Hosting-599709750607614603/original/a5a53bd7-767a-4c36-8946-94ffe6979a3b.jpeg?im_w=720",
               IsCover = false,
               LocationId = location1.Id
            },
            new Image()
            {
               Url = "https://a0.muscache.com/im/pictures/prohost-api/Hosting-599709750607614603/original/14fed897-f191-42a6-8536-6ad4991aa086.jpeg?im_w=720",
               IsCover = false,
               LocationId = location1.Id
            },
          
         };
            location1.Images.AddRange(location1Images);
            var location2Images = new List<Image>()
            {
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/miso/Hosting-34283512/original/5aa2ada7-d4a4-4746-b0f7-2291d9d07552.jpeg?im_w=1200",
                    IsCover = true,
                    LocationId = location2.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/5b41d6c4-80e7-4abd-9e65-0068a93006b4.jpg?im_w=720",
                    IsCover = false,
                    LocationId = location2.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/miso/Hosting-34283512/original/4bfd9403-3386-4773-b5bc-82a9b9f004a3.jpeg?im_w=720",
                    IsCover = false,
                    LocationId = location2.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/bc102505-b059-4a7a-8658-97c36c0d2af6.jpg?im_w=720",
                    IsCover = false,
                    LocationId = location2.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/fb5dda72-1869-4190-9e2e-6cd16debb4f1.jpg?im_w=720",
                    IsCover = false,
                    LocationId = location2.Id
                },
              
            };
            location2.Images.AddRange(location2Images);
            var location3Images = new List<Image>()
            {
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/c9024f77-c25d-495c-9241-08d94079d0d9.jpg?im_w=1200",
                    IsCover = true,
                    LocationId = location3.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/189b6768-417e-4525-a42f-d39a6ea0c95b.jpg?im_w=720",
                    IsCover = false,
                    LocationId = location3.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/de9a25b7-1f4d-4b41-befb-afe8a03de63d.jpg?im_w=720",
                    IsCover = false,
                    LocationId = location3.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/5726d9da-8f44-46c3-8f4c-ae3610d2a825.jpg?im_w=720",
                    IsCover = false,
                    LocationId = location3.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/4f8e5298-9097-47bb-a4a1-864d4e3a6c04.jpg?im_w=720",
                    IsCover = false,
                    LocationId = location3.Id
                },
              
            };
            location3.Images.AddRange(location3Images);
            var deHoutenChaletImages = new List<Image>()
            {
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/3eaee99f-f75b-4eb8-98a5-99971836b600.jpg?im_w=1200",
                    IsCover = true,
                    LocationId = deHoutenChalet.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/303bb029-1c85-4836-a02e-d28d04fb162c.jpg?im_w=720",
                    IsCover = false,
                    LocationId = deHoutenChalet.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/be4c28df-17ff-4ee8-9ca1-7fb867d4f7fa.jpg?im_w=720",
                    IsCover = false,
                    LocationId = deHoutenChalet.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/95715870-420a-46e1-ab4e-99253dc0daca.jpg?im_w=720",
                    IsCover = false,
                    LocationId = deHoutenChalet.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/miso/Hosting-22429934/original/ee1dd08f-0998-425f-85b1-1ec1975f5a26.jpeg?im_w=720",
                    IsCover = false,
                    LocationId = deHoutenChalet.Id
                },
          
            };

            deHoutenChalet.Images.AddRange(deHoutenChaletImages);
            var hetLuxeStrandhuisImages = new List<Image>()
            {
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/prohost-api/Hosting-44970955/original/801785b8-64d5-45d3-a25d-a5f62cdf2ed2.jpeg?im_w=1200",
                    IsCover = true,
                    LocationId = hetLuxeStrandhuis.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/prohost-api/Hosting-44970955/original/fc040aa4-15d5-48c7-8d6e-046d995cf9e8.jpeg?im_w=720",
                    IsCover = false,
                    LocationId = hetLuxeStrandhuis.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/prohost-api/Hosting-44970955/original/9db32a8a-8b56-4157-92a4-8a39bb3d944f.jpeg?im_w=720",
                    IsCover = false,
                    LocationId = hetLuxeStrandhuis.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/prohost-api/Hosting-44970955/original/79cca65b-4fe8-444e-94c8-48987b61164a.jpeg?im_w=720",
                    IsCover = false,
                    LocationId = hetLuxeStrandhuis.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/prohost-api/Hosting-44970955/original/14309683-a315-4677-a92b-7824d7027b9e.jpeg?im_w=720",
                    IsCover = false,
                    LocationId = hetLuxeStrandhuis.Id
                }
            };
            hetLuxeStrandhuis.Images.AddRange(hetLuxeStrandhuisImages);
            var hetZonnigeAppartementImages = new List<Image>()
            {
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/b1553b5d-25c3-4a79-ad5e-baf0160ec2cd.jpg?im_w=1200",
                    IsCover = true,
                    LocationId = hetZonnigeAppartement.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/d485de3b-f169-4d35-aa19-4cd8b58c4a4b.jpg?im_w=720",
                    IsCover = false,
                    LocationId = hetZonnigeAppartement.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/26da82f7-ec18-4e12-8cf4-d7963a3ef616.jpg?im_w=720",
                    IsCover = false,
                    LocationId = hetZonnigeAppartement.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/ef14f96e-9626-4437-a68f-76269bb6fda3.jpg?im_w=720",
                    IsCover = false,
                    LocationId = hetZonnigeAppartement.Id
                },
                new Image()
                {
                    Url = "https://a0.muscache.com/im/pictures/004e274b-8ddc-4d32-93c9-94c3b1c2a1fc.jpg?im_w=720",
                    IsCover = false,
                    LocationId = hetZonnigeAppartement.Id
                }
            };

            hetZonnigeAppartement.Images.AddRange(hetZonnigeAppartementImages);

            var Locations = new List<Location>()
                {       
                       boerenhoeve,
                       frankie,
                       location1,
                       location2,
                       location3,
                       deHoutenChalet,
                       hetZonnigeAppartement,
                       hetLuxeStrandhuis

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
               EndDate = new DateTime(2023, 04, 25),
               CustomerId = customer.Id,
               Customer = customer,
            };
            customer.Reservations.Add(reservation);
            _context.SaveChanges();
         }
      }
   }
}
