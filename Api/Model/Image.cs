using Api.Model;
using Microsoft.CodeAnalysis;

namespace Api.Model
{
   public class Image
   {
      public int Id { get; set; }
      public string Url { get; set; }
      public Landlord Landlord { get; set; }
      public Location Location { get; set; }
      public bool IsCover { get; set; }
      public int? LandLordId { get; set; }
   }
}
