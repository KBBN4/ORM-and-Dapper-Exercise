using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var repo = new DapperProductRepository(conn);


Console.WriteLine(" what is the name of your new product?");
var prodName = Console.ReadLine();

Console.WriteLine( " what is your Price ?");
var prodPrice = int.Parse(Console.ReadLine());

Console.WriteLine(" what is your category ID ?");
var prodID = int.Parse(Console.ReadLine());


repo.CreateProduct(prodName, prodID, prodPrice);

var prodList = repo.GetAllProducts();

foreach ( var prod in prodList)
{
    Console.WriteLine($"{prod.ProductID} & {prod.Name} {prod.CategoryID} ");

}
