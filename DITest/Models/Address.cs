namespace DITest.Models
{
    public class Address
    {
        public Guid id { get; set; }
        public string street { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string country { get; set; }
        public int postcode { get; set; }
        public Guid user_id { get; set; }

    }
}
