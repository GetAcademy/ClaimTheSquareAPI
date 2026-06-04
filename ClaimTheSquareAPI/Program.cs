using ClaimTheSquareAPI.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

var squares = new List<Square>
{
    new Square{Index = 5, Text = "Terje", BackColor = "Blue", ForeColor = "White"},
    new Square{Index = 15, Text = "Per", BackColor = "White", ForeColor = "Green"},
};

app.MapGet("/api/square", () =>
{
    return squares;
});
app.MapPost("/api/square", () =>
{
    return new
    {
        Terje = 5,
    };
});
app.UseStaticFiles();
//app.UseDefaultFiles("index.html");
app.Run();
