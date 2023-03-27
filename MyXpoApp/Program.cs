// See https://aka.ms/new-console-template for more information
using DevExpress.Xpo;
using MyXpoApp;


using System.IO;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
// ...

string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
string connectionString = SQLiteConnectionProvider.GetConnectionString(Path.Combine(appDataPath, "myXpoApp.db"));
XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);


Console.WriteLine("Hello, World!");

Console.WriteLine($"Type some text to create a new 'StatisticInfo' record.");
string userInput = Console.ReadLine();
using (UnitOfWork uow = new UnitOfWork())
{
    StatisticInfo newInfo = new StatisticInfo(uow);
    newInfo.Info = userInput;
    newInfo.Date = DateTime.Now;
    uow.CommitChanges();

}
// Read data:
Console.WriteLine($"Your text is saved. The 'StatisticInfo' table now contains the following records:");
using (UnitOfWork uow = new UnitOfWork())
{
    var query = uow.Query<StatisticInfo>()
        .OrderBy(info => info.Date)
        .Select(info => $"[{info.Date}] {info.Info}");
    foreach (var line in query)
    {
        Console.WriteLine(line);
    }
}
// Delete data:
using (UnitOfWork uow = new UnitOfWork())
{
    var itemsToDelete = uow.Query<StatisticInfo>().ToList();
    Console.Write($"Records count is {itemsToDelete.Count}. Do you want to delete all records (y/N)?: ");
    if (Console.ReadLine().ToLowerInvariant() == "y")
    {
        uow.Delete(itemsToDelete);
        uow.CommitChanges();
        Console.WriteLine($"Done.");
    }
}
