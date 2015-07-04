using System;
using System.Linq;
/* Purpose: Calculates which day of the week a given date fell on.
 * Developer: Adam K
 * Date: 7/3/2015
 * Notes: These algorithms are based off rules found on: http://www.searchforancestors.com/utility/dayofweek.html
 */

namespace DayOfWeekSolver
{
    class DayOfWeekSolver

    {
        static void Main()
        {
            // Variables
            string dayCode,
                monthCode,
                yearCode,
                centuryCode;

            // Intructions
            DisplayInstructions();

            // Inputs
           var inputs = GetInputs();

            // Extract Values
            ExtractValues(ref inputs, out dayCode, out monthCode, out centuryCode, out yearCode);

            // Check Inputs
            CheckInputs(ref dayCode, ref monthCode, ref centuryCode, ref yearCode);

            // Input Results
            int month = Convert.ToInt32(monthCode);
            int day = Convert.ToInt32(dayCode);
            int century = Convert.ToInt32(centuryCode);
            int year = Convert.ToInt32(yearCode);

            // Instantiate
            DayOfWeekSolverClass instance1 = new DayOfWeekSolverClass(month, day, century, year);

            // Output
            Console.Write("\n\n" + monthCode + "/" + dayCode + "/" + centuryCode + yearCode + " was on: ");
            Console.WriteLine(instance1);
            Console.ReadKey();

            // Loop Program
            LoopProgramInstructions();
            LoopProgram();

        }

        public static void DisplayInstructions()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tDay of Week Solver");
            Console.WriteLine("\n\nThis application is made to return a day of the week.");
            Console.WriteLine("It calculates the date entered and assigns values base on:");
            Console.WriteLine("\t\t- Days \t\t\t- Months");
            Console.WriteLine("\t\t- Centuries \t\t- Years");
            Console.WriteLine("\t\t- Leap Years \t\t- And more");
            Console.Write("\nTo enter a desired date, press any key...");
            Console.ReadKey();
        }

        public static string GetInputs()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tDay Of Week Solver");
            Console.WriteLine("\n\nEnter date below mm/dd/yyyy:");
            Console.Write("\t\t ");
            string captureString = Console.ReadLine();

            // Check that input contains 10 characters
            if (captureString.Length != 10)
            {
                Console.WriteLine("\nThe date entered was not spaced correctly.");
                Console.WriteLine("Remember to follow the format shown: mm/dd/yyyy");
                Console.WriteLine("Use 0's for single dates - example:  03/01/1900");
                Console.Write("Press any key to return to the input menu...");
                Console.ReadKey();

                GetInputs();
            }

            // Check that input follows correct format (mm/dd/yyyy)
            string filterString = captureString;
            string filterBackslash = "/";
            int filterCount = (captureString.Length - filterString.Replace(filterBackslash, "").Length);

            if (filterCount != 2)
            {
                Console.WriteLine("\nThe date entered was not formatted correctly.");
                Console.WriteLine("Remember to follow the format shown: (mm/dd/yyyy)");
                Console.Write("Press any key to return to the input menu...");
                Console.ReadKey();

                GetInputs();
            }

            string inputString = captureString;

            return inputString;
        }

        public static void ExtractValues(ref string inputs, out string dayCode, out string monthCode, out string centuryCode, out string yearCode)
        {
            // Split format into months, days, years
            string[] dates = inputs.Split('/');

            // assign days
           dayCode = dates[1];
            // assign months
            monthCode = dates[0];
            // assign years
            string year = dates[2];
            // break and assign century (yy_ _)
            centuryCode = year.Remove(2, 2);
            // break and assign years (_ _yy)
            yearCode = year.Remove(0, 2);
        }

        public static void CheckInputs(ref string dayCode, ref string monthCode, ref string centuryCode, ref string yearCode)
        {
            int input1,
                input2,
                input3,
                input4;
            int[] daysInMonths =
            {
                31, 29, 31, 30,
                31, 30, 31, 31,
                30, 31, 30, 31
            };

            // check month - as number
            if (int.TryParse(monthCode, out input1) == false)
            {
                Console.WriteLine("\n*{0} is an invalid month input.", input1);
                Console.WriteLine("Inputs should contain 2 digits.");
                InputError();
            }

            // check month - has to be 1 through 12
            if (input1 > 12 || input1 == 0)
            {
                Console.WriteLine("\n*{0} is an invalid month input.", input1);
                Console.WriteLine("Inputs should be months (1-12).");
                InputError();
            }

            // check day - as number
            if (int.TryParse(dayCode, out input2) == false)
            {
                Console.WriteLine("\n*{0} is an invalid day input.", input2);
                Console.WriteLine("Inputs should contain 2 digits.");
                InputError();
            }

            // check day - days exist within their months
                // check that days is an integer
            if (input2 > -1)
            {
                // cycle through possible months (12)
                for (int i = 1; i < 13; i++)
                {
                    // until month(input1) matches
                    if (input1 == i)
                    {
                        // cycle through days in months list
                        for (int j = 0; j < daysInMonths.Count(); j++)
                        {
                            // check that input2 is less than possible days in that month
                            if (input2 > daysInMonths[i-1] || input2 == 0)
                            {
                                Console.WriteLine("\n*{0} is an invalid day input.", input2);
                                Console.WriteLine("The selected month doesn't contain {0} days.", input2);
                                InputError();
                            }
                        }
                    }
                }
            }

            // check century - as number
            if (int.TryParse(centuryCode, out input3) == false)
            {
                Console.WriteLine("\n*{0} is an invalid century (yy__) input.", input3);
                Console.WriteLine("Inputs should be intergers.");
                InputError();
 
            }

            // check year - as number
            if (int.TryParse(yearCode, out input4) == false)
            {
                Console.WriteLine("\n*{0} is an invalid century (__yy) input.", input4);
                Console.WriteLine("Inputs should be intergers.");
                InputError();
            }
        }

        public static void InputError()
        {
            Console.WriteLine("Press any key to return to the input page...");
            Console.ReadKey();
            GetInputs();
        }

        public static void LoopProgramInstructions()
        {
            Console.WriteLine("\nWould you like to run the program again?");
            Console.Write("If so, please type \"Y\": ");
        }

        public static void LoopProgram()
        {
            String inputValue = Console.ReadLine();
            char loopProgram = 'Y';
            // Check inputValue for char
            if (char.TryParse(inputValue, out loopProgram) == false)
            {
                ;
            }
            // Check loopProgram for yes
            if (loopProgram == 'y' || loopProgram == 'Y')
            {
                Console.Clear();
                Main();
            }

        }
    }
}
