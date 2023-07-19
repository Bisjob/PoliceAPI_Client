// See https://aka.ms/new-console-template for more information
using PoliceAPI_Client.Models;
using PoliceAPI_Client.Services.Implementations;


CrimeService crimeService = new CrimeService();

var coord = new Coordinate(52.629729f, -1.131592f);
var poly = new Polygon(new List<Coordinate> 
    { 
        new Coordinate(52.268f, 0.543f), 
        new Coordinate(52.794f, 0.238f), 
        new Coordinate(52.130f, 0.478f), 
    });
string date = DateTime.Now.AddMonths(-6).ToString("yyyy-MM");

//var crimes = await crimeService.GetStreetLevelCrimes(coord, date);
//Console.WriteLine($"{crimes.Count()} crimes found at given coordinate");


//var crimes2 = await crimeService.GetStreetLevelCrimes(poly, date);
//Console.WriteLine($"{crimes2.Count()} crimes found inside a polygon");


var outcomes = await crimeService.GetStreetLevelOutcomes(date, coord);
Console.WriteLine($"{outcomes.Count()} outcomes found at given coordinate");

var outcomes2 = await crimeService.GetStreetLevelOutcomes(date, poly);
Console.WriteLine($"{outcomes2.Count()} outcomes found inside a polygon");