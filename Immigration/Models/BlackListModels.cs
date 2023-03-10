namespace Immigration.Models
{
    public class BlackListModels
    {
        public long Id { get; set; }
        public string? Surname { get; set; }
        public string? Given_name { get; set; }
        public string? Birth_of_date { get; set; }
        public string? Sex { get; set; }
        public string? Country { get; set; }
        public string? Birth_Country { get; set; }
        public int? Document_No { get; set; }
        public string? Remarks { get; set; }
        public string? Mode { get; set; }

    }
}
