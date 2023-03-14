namespace Immigration.Models
{
    public class PassportDataModel
    {
        public PassportDataModel() 
        {
            Id = new List<long>();
            Name= new List<string>();
            Surname= new List<string>();
            BirthOfDate= new List<string>();
            Sex = new List<string>();
            Country = new List<string>();
            BirthCountry= new List<string>();
            DocumentNo = new List<int?>();
            ImagePath= new List<string>();
        }
        public List<long> Id { get; set; }
        public List<string?> Name { get; set; }
        public List<string?> Surname { get; set; }
        public List<string?> BirthOfDate { get; set; }
        public List<string?> Sex { get; set; }
        public List<string?> Country { get; set; }
        public List<string?> BirthCountry { get; set; }
        public List<int?> DocumentNo { get; set; }
        public List<string?> ImagePath { get; set; }
    }
}
