namespace Api.Model
{
   public class Landlord
   {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int Age { get; set; }
      public Image Avatar { get; set; }
      public List<Location> Locations { get; set; }
      public int AvatarId { get; set; }

      public Landlord()
      {
         Locations = new List<Location>();
      }
   }
}
