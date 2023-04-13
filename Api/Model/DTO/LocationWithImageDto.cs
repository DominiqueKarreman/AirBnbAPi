namespace Api.Model.DTO
{
    public class LocationWithImageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string landlordAvatarURL { get; set; }
    }
}
