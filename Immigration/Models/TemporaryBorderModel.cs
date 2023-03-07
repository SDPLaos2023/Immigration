namespace Immigration.Models
{
    public class TemporaryBorderModel
    {
        public long Id { get; set; }
        public string? Surname { get; set; }
        public string? GivenName { get; set; }
        public string? BirthOfDate { get; set; }
        public string? Sex { get; set; }
        public string? Country { get; set; }
        public string? BirthCountry { get; set; }
        public int? DocumentNo { get; set; }
    }
}
