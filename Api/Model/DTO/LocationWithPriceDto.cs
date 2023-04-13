namespace Api.Model.DTO
{
    public class LocationWithPriceDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string landlordAvatarURL { get; set; }
        public float Price { get; set; }
        public int Type { get; set; }
    }
}
