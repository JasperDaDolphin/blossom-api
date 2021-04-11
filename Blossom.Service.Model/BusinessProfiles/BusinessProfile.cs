namespace Blossom.Service.Model.BusinessProfiles
{
    public class BusinessProfile : ModelWithGuidId
    {
        public string Name { get; set; }

        public string Website { get; set; }

        public string Size { get; set; }

        public string Number { get; set; }

        public string Type { get; set; }
    }
}