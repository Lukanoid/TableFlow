namespace TableFlow.Domain.Tests
{
    public class VenueTests
    {
        //Constructor and identity tests
        [Theory]
        [InlineData("AB")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void Constructor_InvalidName_ThrowsArgumentException(string? invalidName)
        {

            Action act = () => new Venue(1, 1, invalidName, VenueType.Restaurant, "Europe/Sofia");

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Constructor_ValidData_CreatesVenue()
        {
            int id = 1;
            int organizationId = 1;
            string name = "Valid Venue Name";
            VenueType venueType = VenueType.Restaurant;
            string timeZoneId = "Europe/Sofia";

            Venue venue = new Venue(id, organizationId, name, venueType, timeZoneId);

            Assert.Equal(id, venue.Id);
            Assert.Equal(organizationId, venue.OrganizationId);
            Assert.Equal(name, venue.Name);
            Assert.Equal(venueType, venue.VenueType);
            Assert.Equal(timeZoneId, venue.TimeZoneId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_InvalidId_ThrowsArgumentException(int invalidId)
        {
            Action act = () => new Venue(invalidId, 1, "Valid Name", VenueType.Restaurant, "Europe/Sofia");

            Assert.Throws<ArgumentException>(act);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_InvalidOrganizationId_ThrowsArgumentException(int invalidOrganizationId)
        {
            Action act = () => new Venue(1, invalidOrganizationId, "Valid Name", VenueType.Restaurant, "Europe/Sofia");

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Constructor_NameWithWhitespace_TrimmedName()
        {
            string nameWithWhitespace = "   ValidName   ";

            Venue venue = new Venue(1, 1, nameWithWhitespace, VenueType.Restaurant, "Europe/Sofia");

            Assert.Equal("ValidName", venue.Name);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(2, false)]
        [InlineData(3, true)]
        [InlineData(101, false)]
        [InlineData(100, true)]
        public void Constructor_NameLengthValidation(int lenght, bool isValid)
        {
            string name = new string('A', lenght);
            if (isValid)
            {
                Venue venue = new Venue(1, 1, name, VenueType.Restaurant, "Europe/Sofia");
                Assert.Equal(name, venue.Name);
            }
            else
            {
                Action act = () => new Venue(1, 1, name, VenueType.Restaurant, "Europe/Sofia");
                Assert.Throws<ArgumentException>(act);
            }
        }

        //ChangeName method tests

        [Fact]
        public void ChangeName_ValidName_ChangesName()
        {
            Venue venue = new Venue(1, 1, "Old Name", VenueType.Restaurant, "Europe/Sofia");

            venue.ChangeName("New Name");

            Assert.Equal("New Name", venue.Name);
        }

        [Fact]
        public void ChangeName_NameWithWhitespace_TrimmedName()
        {
            Venue venue = new Venue(1, 1, "Old Name", VenueType.Restaurant, "Europe/Sofia");

            venue.ChangeName("   New Name   ");

            Assert.Equal("New Name", venue.Name);
        }

        [Theory]
        [InlineData("AB")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void ChangeName_InvalidName_ThrowsAndPreservesOriginalName(string? name)
        {
            Venue venue = new Venue(1, 1, "Old Name", VenueType.Restaurant, "Europe/Sofia");

            Assert.Throws<ArgumentException>(() => venue.ChangeName(name));
            Assert.Equal("Old Name", venue.Name);
        }

        //VenueTypes tests

        [Theory]
        [InlineData(VenueType.Restaurant)]
        [InlineData(VenueType.Bar)]
        [InlineData(VenueType.Nightclub)]
        public void Constructor_ValidVenueType_CreatesVenue(VenueType validVenue)
        {

            Venue venue = new Venue(1, 1, "Valid Name", validVenue, "Europe/Sofia");

            Assert.Equal(validVenue, venue.VenueType);
        }

        [Fact]
        public void Constructor_InvalidVenueType_ThrowsArgumentException()
        {
            VenueType invalidVenueType = (VenueType)999;

            Assert.Throws<ArgumentException>(() => new Venue(1, 1, "Valid Name", invalidVenueType, "Europe/Sofia"));
        }

        //TimeZoneId tests

        [Fact]
        public void Constructor_ValidTimeZone_CreatesVenue()
        {
            string validTimeZoneId = "Europe/Sofia";

            Venue venue = new Venue(1, 1, "Valid Name", VenueType.Restaurant, validTimeZoneId);

            Assert.Equal(validTimeZoneId, venue.TimeZoneId);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("Europe/InvalidCity")]
        [InlineData("Invalid/Sofia")]
        public void Constructor_InvalidTimeZone_ThrowsArgumentException(string? timeZoneId)
        {
            Action act = () => new Venue(1, 1, "Valid name", VenueType.Restaurant, timeZoneId);

            Assert.Throws<ArgumentException>(act);

        }
    }
}
