using ProcessMultiTasking;
using ProcessMultiTasking.Models;

Console.WriteLine("Test multi-threading!");

DataStore.Initialize();

Company c1 = new();
c1.SearchCompanyCodesAsync("A", "B", "C", "D", "E", "F");
