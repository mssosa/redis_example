// See https://aka.ms/new-console-template for more information
using Pipelines.Sockets.Unofficial;
using redis_example_console;
using StackExchange.Redis;


Console.WriteLine("Testing redis!");

var db = new RedisDB();
var redisDB = db.Connection.GetDatabase();

Console.WriteLine($"Adding values....");
//redisDB.StringSet("1", "Fender");
//redisDB.StringSet("2", "Gibson");
//redisDB.StringSet("3", "PRS");
//redisDB.StringSet("4", "Gretch");
//redisDB.StringSet("5", "Epiphone");

Random rnd = new Random();
var nextNumber = rnd.Next(1, DateTime.Now.Second);
Console.WriteLine($"Quantity to add => [{nextNumber}]");
for (int i = 0; i < nextNumber; i++)
{
    redisDB.StringSet(i.ToString(), nextNumber);
}



// show all keys in database 0 that include "foo" in their name
Console.WriteLine($"All values....");

// Connect to a target server using your ConnectionMultiplexer instance
IServer server = db.Connection.GetServer("localhost", 6379);
// Write out each key in the server
var keys = server.Keys().ToList();
foreach (var key in keys)
{
    Console.WriteLine($"[\"{key}\"]-[\"{ redisDB.StringGet(key.ToString())}\"]");
}


Console.Read();


