# Day-Of-Week-Solver
Calculates which day of the week a given date occurred.

Using my own algorithm, this application assigns values to the month, day, and year portion of any date.
I made this based on the facts from this site: http://www.searchforancestors.com/utility/dayofweek.html

All dates entered must match this format: mm/dd/yyyy
Errors will be prompted for all invalid input values.

**This tool only works for any date after the year 1600 due to implemention of the Gregorian calender.

EDIT: The DayOfWeek default libraries are over-rated, but if you want to simplify this project to one line:
```
Console.WriteLine(DateTime.Parse(Console.ReadLine()).DayOfWeek);
```
<br/>
^ Credit to my friend Assault
