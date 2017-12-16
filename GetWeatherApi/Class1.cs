using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetWeatherApi
{
    public class Class1
    {
        public class coord
        {
            public double Ion { get; set; }
            public double Lat { get; set; }
        }// end of coord class

        public class Weather
        {
            public int Id { get; set; }
            public string Main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }// of weather class

        public class Main
        {
            public double Temp { get; set; }
            public double Pressure { get; set; }
            public double Humidity { get; set; }
            public double temp_max { get; set; }
            public double temp_min { get; set; }
        }//end of Main Class

        public class Wind
        {
            public double Speed { get; set; }

        }// End of wind class
        public class Sys
        {
            public string Country { get; set; }
            public int SunRise { get; set; }


        }// End of Sys class

        public class root
        {
            public string Name { get; set; }
            public Sys sys { get; set; }
            public double dt { get; set; }
            public Wind wind { get; set; }
            //public Wind  { get; set; }
            public Main Main { get; set; }
            public List<Weather> weather { get; set; }
            public coord Cordinate { get; set; }
        }
    }
}

