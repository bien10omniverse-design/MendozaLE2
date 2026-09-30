using BlogDataLibrary.Data;
using BlogDataLibrary.Database;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

ISqlDataAccess db = new SqlDataAccess(config);
SqlData data = new SqlData(db);

Console.WriteLine("Blog Database Test");
Console.WriteLine("-------------------");

List<BlogDataLibrary.Models.UserModel> users = data.LoadUsers();

foreach (var user in users)
{
    Console.WriteLine($"ID: {user.Id}");
    Console.WriteLine($"Username: {user.UserName}");
    Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
    Console.WriteLine();
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();