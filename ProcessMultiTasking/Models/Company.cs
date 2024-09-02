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
        var delay = (int)Random.Shared.NextInt64(3000, 20000);
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
