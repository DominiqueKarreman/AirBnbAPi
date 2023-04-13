using Api.Model;
using Microsoft.CodeAnalysis;

namespace Api.Model
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int? LocationId { get; set; }
        public bool IsCover { get; set; }
    }
}
