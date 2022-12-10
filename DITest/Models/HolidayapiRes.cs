﻿namespace DITest.Models
{
    public class HolidayapiRes
    {
        public int status { get; set; }
        public string warning { get; set; }
        public Requests requests { get; set; }
        public Holiday[] holidays { get; set; }
    }

    public class Requests
    {
        public int used { get; set; }
        public int available { get; set; }
        public string resets { get; set; }
    }

    public class Holiday
    {
        public string name { get; set; }
        public string date { get; set; }
        public string observed { get; set; }
        public bool _public { get; set; }
        public string country { get; set; }
        public string uuid { get; set; }
        public Weekday weekday { get; set; }
    }

    public class Weekday
    {
        public Date date { get; set; }
        public Observed observed { get; set; }
    }

    public class Date
    {
        public string name { get; set; }
        public string numeric { get; set; }
    }

    public class Observed
    {
        public string name { get; set; }
        public string numeric { get; set; }
    }

}
