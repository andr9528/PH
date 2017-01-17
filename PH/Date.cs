using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH
{
    public class Date
    {
        
        public int Day { get; internal set; }
        public int Month { get; internal set; }
        public int Year { get; internal set; }
        public string Type { get; internal set; }
        public int DateID { get; internal set; }
        public Date()
        {

        }
        public Date(int _day, int _month, int _year, string _type, int _dateID)
        {
            Day = _day;
            Month = _month;
            Year = _year;
            Type = _type;
            DateID = _dateID;
        }
        
        public string ToStringD()
        {
            string output;

            output = Day + "." + Month + "." + Year + "." + Type + "." + DateID;

            return output; 
        }
    }
}
