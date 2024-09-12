using System;

namespace ProcessMultiTasking.Models;

public class Company
{
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;

    public string CompanyCode { get; set; } = default!;
    public static List<string> CompanyNames { get; set; } = new();

    public void SearchCompanyCode() {
        var start = DateTime.Now;
        Console.WriteLine($"Start task for {CompanyCode}");
        /*
        The delay simulates the work for each company.
        By setting it to a constant 5000 ms (5 seconds)
        all the 6 companies finish after only 5 seconds
        instead of each company running 5 seconds by run
        one after another which would mean it would take 
        30 seconds for all companies to complete
        */
        var delay = 5000; //(int)Random.Shared.NextInt64(3000, 20000);
        Console.WriteLine($"{CompanyCode}: delay {delay / 1000} seconds.");
        Thread.Sleep(delay);
        var company = DataStore.Companies.SingleOrDefault(c => c.Code == CompanyCode);
        CompanyNames.Add(company is null ? "MISSING" : company.Name);
        var timespan = DateTime.Now - start;
        Console.WriteLine($"End task for {CompanyCode} ran for {timespan.TotalSeconds:N0} seconds.");
    }
    public void SearchCompanyCodesAsync(params string[] Codes) {
        Console.WriteLine(DateTime.Now);
        List<Task> tasks = new();
        foreach(var code in Codes) {
            Company company = new() { CompanyCode = code };
            Task task = new Task(() => company.SearchCompanyCode());
            tasks.Add(task);
            task.Start();
            //task.Wait();
        }
        Task.WaitAll(tasks.ToArray());
        Console.WriteLine(string.Join(" | ", CompanyNames));
        Console.WriteLine(DateTime.Now);
    }
}
