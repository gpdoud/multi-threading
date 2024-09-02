using System;
using System.ComponentModel.Design;
using ProcessMultiTasking.Models;

namespace ProcessMultiTasking;

public static class DataStore
{
    public static List<ReferenceImportData> RefImportData = new();
    public static List<Company> Companies = new();
    public static List<Account> Accounts = new();

    public static void Initialize() 
    {
        // load data to be imported
        RefImportData.Add(new ReferenceImportData { CompanyCode = "ABC", AccountCode = "123" });
        RefImportData.Add(new ReferenceImportData { CompanyCode = "BCD", AccountCode = "234" });
        RefImportData.Add(new ReferenceImportData { CompanyCode = "CDE", AccountCode = "345" });
            
        // load Company
        Companies.Add(new Company { Code = "A", Name = "A Company" });
        Companies.Add(new Company { Code = "B", Name = "B Company" });
        Companies.Add(new Company { Code = "C", Name = "C Company" });
        Companies.Add(new Company { Code = "D", Name = "D Company" });
        Companies.Add(new Company { Code = "E", Name = "E Company" });
        Companies.Add(new Company { Code = "F", Name = "F Company" });

        // load Account
        Accounts.Add(new Account { Code = "123", Name = "123 Account" });
        Accounts.Add(new Account { Code = "234", Name = "234 Account" });
        Accounts.Add(new Account { Code = "345", Name = "345 Account" });
    }
}
