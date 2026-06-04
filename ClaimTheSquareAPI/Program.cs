using ClaimTheSquareAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/api/square", SquareRepository.GetAll);
app.MapPost("/api/square", SquareRepository.AddSquare);
app.UseStaticFiles();
app.Run();


/*

CRUD

- Create - legge til nye data         * ClaimTheSquare
- Read   - lese data                  * ClaimTheSquare
- Update - endre data
- Delete - slette data


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