namespace AspNet.Models
{
    public class AboutMeViewModel
    {
        public Dictionary<string, (string, string)> Jobs { get; set; }
        public Dictionary<string, string> Skills { get; set; }
        public List<string> Hobbies { get; set; }
    }
}
