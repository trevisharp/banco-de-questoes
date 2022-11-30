using static System.Console;
using System.Linq;
using System.Collections.Generic;

var days = getDays();
var bikes = getSharings();

var query = 
    from d in days
    join b in bikes
    on d.Day equals b.Day
    select new {
        Day = b.Day,
        BikeSharing = b.Casual + b.Registred,
        Season = d.Season,
        Temp = d.Temp,
        IsWorkingDay = d.IsWorkingDay,
        Weather = d.Weather
    } into x
    orderby x.BikeSharing
    select x;

foreach (var x in query)
    WriteLine(x);


IEnumerable<DayInfo> getDays()
{
    StreamReader reader = new StreamReader("dayInfo.csv");
    reader.ReadLine();

    while (!reader.EndOfStream)
    {
        var data = reader.ReadLine().Split(',');
        DayInfo info = new DayInfo();

        info.Day = int.Parse(data[0]);
        info.Season = int.Parse(data[1]);
        info.IsWorkingDay = int.Parse(data[2]) == 1;
        info.Weather = int.Parse(data[3]);
        info.Temp = float.Parse(data[4].Replace('.', ','));

        yield return info;
    }

    reader.Close();
}

IEnumerable<BikeSharing> getSharings()
{
    StreamReader reader = new StreamReader("bikeSharing.csv");
    reader.ReadLine();

    while (!reader.EndOfStream)
    {
        var data = reader.ReadLine().Split(',');
        BikeSharing sharing = new BikeSharing();
        
        sharing.Day = int.Parse(data[0]);
        sharing.Casual = int.Parse(data[1]);
        sharing.Registred = int.Parse(data[2]);

        yield return sharing;
    }

    reader.Close();
}

public class DayInfo
{
    public int Day { get; set; }
    public int Season { get; set; }
    public bool IsWorkingDay { get; set; }
    public int Weather { get; set; }
    public float Temp { get; set; }
}

public class BikeSharing
{
    public int Day { get; set; }
    public int Casual { get; set; }
    public int Registred { get; set; }
}