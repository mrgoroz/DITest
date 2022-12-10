namespace DITest.Models
{
    public class Timeslot
    {
        public int id { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Delivery? delivery_1 { get; set; }
        public Delivery? delivery_2 { get; set; }

    }
}
