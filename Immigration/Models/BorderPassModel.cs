namespace Immigration.Models
{
    public class BorderPassModel
    {
        public long Id { get; set; }
        public string? Surname { get; set; }
        public string? GivenName { get; set; }
        public string? BirthOfDate { get; set; }
        public string? Sex { get; set; }
        public string? Country { get; set; }
        public string? Village { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
        public int? DocumentNo { get; set; }
        public string? Occupation { get; set; }
    }
}
