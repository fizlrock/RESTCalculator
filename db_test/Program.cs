
using Microsoft.EntityFrameworkCore;
using Calc.Models;

string connection = "Data Source=/home/fizlrock/code/hobby/Calculator/db_test/mydb.db;";

var options_builder = new DbContextOptionsBuilder<MathRequestContext>();
options_builder.UseSqlite(connection);
options_builder.LogTo(Console.WriteLine);
MathRequestContext db = new MathRequestContext(options_builder.Options);
db.Database.EnsureDeleted();
db.Database.EnsureCreated();


var pair = new InfixPOLISPair()
{
    Infix = "fuck",
    POLIS = "you"
};

db.InfixPOLISPairs.Add(pair);
db.SaveChanges();
db.Database.CloseConnection();
Console.WriteLine("Hello, World!");

