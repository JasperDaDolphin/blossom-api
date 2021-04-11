namespace Blossom.Data.Model.BusinessProfiles
{
    public class BusinessProfileEntity : EntityWithGuidId
    {
        public string Name { get; set; }

        public string Website { get; set; }

        public string Size { get; set; }

        public string Number { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }
    }
}