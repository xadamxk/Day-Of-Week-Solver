using System.Linq;
/* Purpose: Assign values to various days, months, years, and centuries.
 * Developer: Adam K
 * Date: 7/3/2015
 * Notes: These algorithms are based off rules found on: http://www.searchforancestors.com/utility/dayofweek.html
 */

namespace DayOfWeekSolver
{
    class DayOfWeekSolverClass
    {
        // Constants
        private string[] dayCodes = 
        {"Sunday", "Monday", "Tuesday", 
         "Wednesday", "Thursday", "Friday",
         "Saturday"};

        private int[] monthCodes =
        {
            6, 2, 2, 5,
            0, 3, 5, 1,
            4, 6, 2, 4
        };

        // Data Fields
        private int month,
            day,
            century,
            year;

        private bool leapYear = false;

        // Properties
        public int Month { get; set; }
        public int Day { get; set; }
        public int Century { get; set; }
        public int Year { get; set; }
        public bool LeapYear { get; set; }

        // Constructor
            // Default
        public DayOfWeekSolverClass()
        {
            
        }

            // Containing inputs
        public DayOfWeekSolverClass(int mo, int da, int ce, int ye)
        {
            month = mo;
            day = da;
            century = ce;
            year = ye;

        }

        // Methods
            // Calculate Year Code
        public int CalculateYearCode()
        {
            int yearCode = 0;
            int leap = year % 28;

            // Leap if yy = 00
            if (leap == 0)
            {
                // Leap if yy00 % 400 = 0
                if (century % 4 == 0)
                {
                    leapYear = true;
                }
            }

            int leapCount = leap % 4;

            // Leap if yy % 28 = 00, 04, 08, 12, 16, 20, 24
            if (leapCount == 0)
            {
                leapYear = true;
            }

            if (leapYear)
            {
                switch (leap)
                {
                    case 00:
                        yearCode = 0;
                        break;
                    case 04:
                        yearCode = 5;
                        break;
                    case 08:
                        yearCode = 3;
                        break;
                    case 12:
                        yearCode = 1;
                        break;
                    case 16:
                        yearCode = 6;
                        break;
                    case 20:
                        yearCode = 4;
                        break;
                    case 24:
                        yearCode = 2;
                        break;
                }
            }

            int leapYearNum = 0;
            int leapYearCod = 0;

            if (leapYear == false)
            {
                if (leap > 0 && leap < 4)
                {
                    leapYearNum = 0;
                    leapYearCod = 0;
                }

                if (leap > 4 && leap < 8)
                {
                    leapYearNum = 4;
                    leapYearCod = 5;
                }

                if (leap > 8 && leap < 12)
                {
                    leapYearNum = 8;
                    leapYearCod = 3;
                }

                if (leap > 12 && leap < 16)
                {
                    leapYearNum = 12;
                    leapYearCod = 1;
                }

                if (leap > 16 && leap < 20)
                {
                    leapYearNum = 16;
                    leapYearCod = 6;
                }

                if (leap > 20 && leap < 24)
                {
                    leapYearNum = 20;
                    leapYearCod = 4;
                }

                if (leap > 24 && leap < 28)
                {
                    leapYearNum = 24;
                    leapYearCod = 2;
                }
                if (leapYear == false)
                {
                    // Eq. = % 28 + (previous leap year) - (previous leap year code)
                    year = year%28; 
                    // leap = year % 28;
                    // year = _ _ yy
                    // leapYearCod = code for that leap year
                    yearCode = leapYearCod + (year - leapYearNum);
                }
            }

            return yearCode;

        }
            // Caculate Day Code
        public int CalculateDayCode()
        {
            int dayCode = day % 7;

            return dayCode; 
        }
            // Calculate Month Code
        public int CalculateMonthCode()
        {
            int monthCode = 0;

            // Cycle through monthCodes (1 - Jan ... 12 - Dec)
                for (int i = 0; i < monthCodes.Count(); i++)
                {
                    if ((i + 1) == month)
                    {
                        // If Jan + Leap Year
                        if (month == 1 && leapYear)
                        {
                            monthCode = 5;
                        }
                            // If Feb + Leap Year
                        else if (month == 2 && leapYear)
                        {
                            monthCode = 1;
                        }
                            // Everything else
                        else
                        {
                            monthCode = monthCodes[i];
                        }
                    }
                }

            return monthCode;
        }
            // Calculate Century Code
        public int CalculateCenturyCode()
        {
            int centuryCode = 0;
            int tempCenturyCode = 0;

            tempCenturyCode = century % 4;

            switch (tempCenturyCode)
            {
                case 0:
                    centuryCode = 0;
                    break;
                case 1:
                    centuryCode = 5;
                    break;
                case 2:
                    centuryCode = 3;
                    break;
                case 3:
                    centuryCode = 1;
                    break;
            }

            return centuryCode;
        }
            // Calculate Date Code
        public override string ToString()
        {
            string dateCode = "";
            int tempDateCode = 0;

            int calcYearCode = CalculateYearCode();
            int calcDayCode = CalculateDayCode();
            int calcMonthCode = CalculateMonthCode();
            int calcCenturyCode = CalculateCenturyCode();

            tempDateCode = (calcDayCode + calcMonthCode + calcYearCode + calcCenturyCode)%7;

            // Determine day of week based on total values
            for (int i = 0; i < dayCodes.Length; i++)
            {
                if (tempDateCode == (i))
                {
                    dateCode = dayCodes[i];
                }

            }

            // Check if year was before 1600
            if (century < 16)
            {
                dateCode += "\n\n** This application only works with dates AFTER the year 1600.\n" +
                            "Expect any dates prior to be incorrect (conflicts with the Gregorian calender).";
            }

            return dateCode;
        }
    }
}
