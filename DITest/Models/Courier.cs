namespace DITest.Models
{
    public class Courier
    {
        public Time[] times { get; set; }
    }

    public class Time
    {
        public int day { get; set; }
        public int start_time { get; set; }
        public int end_time { get; set; }
    }

}
