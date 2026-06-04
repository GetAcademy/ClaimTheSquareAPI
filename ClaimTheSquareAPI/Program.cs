using System.Text.Json;
using ClaimTheSquareAPI.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

var fileName = "squares.json";

app.MapGet("/api/square", () =>
{
    if (!File.Exists(fileName)) return Array.Empty<Square>();
    var json = File.ReadAllText("squares.json");
    return JsonSerializer.Deserialize<Square[]>(json);
});

app.MapPost("/api/square", (Square square) =>
{
    var squares = new List<Square>();
    if (File.Exists(fileName))
    {
        var json1 = File.ReadAllText(fileName);
        var squaresArray = JsonSerializer.Deserialize<Square[]>(json1);
        squares.AddRange(squaresArray);
    }

    squares.Add(square);
    var json2 = JsonSerializer.Serialize(squares);
    File.WriteAllText(fileName, json2);
});
app.UseStaticFiles();
//app.UseDefaultFiles("index.html");
app.Run();


/*
   using ClaimTheSquareAPI.DTOs;
   
   var builder = WebApplication.CreateBuilder(args);
   var app = builder.Build();
   app.UseHttpsRedirection();
   
   var squares = new List<Square>
   {
       new Square{Index = 50, Text = "Terje", BackColor = "Blue", ForeColor = "White"},
       new Square{Index = 15, Text = "Per", BackColor = "White", ForeColor = "Green"},
   };
   
   app.MapGet("/api/square", () =>
   {
       return squares;
   });
   app.MapPost("/api/square", (Square square) =>
   {
       squares.Add(square);
   });
   app.UseStaticFiles();
   //app.UseDefaultFiles("index.html");
   app.Run();
    
 */