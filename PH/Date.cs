using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH
{
    class Date
    {
        List<Date> dateList = new List<Date>();
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
        public void newDate(int day, int month, int year, string type, int dateID)
        {
            bool doesNotAlreadyExist = true;

            foreach (Date date in dateList)
            {
                if (date.ToStringD().Split('.')[4].Contains(dateID.ToString()))
                {
                    doesNotAlreadyExist = false;
                }
            }

            if (day <= 31 && day >= 1
                && month <= 12 && month >= 1
                && (type == "Order" || type == "Delivery")
                && doesNotAlreadyExist == true)
            {
                Date date = new Date(day, month, year, type, dateID);

                dateList.Add(date);
            }
            else
            {
                throw new Exception("invalid day or month, type can only be *Order* or *Delivery*, the dateID must not already exist ");
            }
        }
        public List<Date> getDateList()
        {
            return dateList;
        }
        public string ToStringD()
        {
            string output;

            output = Day + "." + Month + "." + Year + "." + Type + "." + DateID;

            return output; 
        }
    }
}
