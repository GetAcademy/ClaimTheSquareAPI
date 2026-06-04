using ClaimTheSquareAPI.DTOs;
using System.Text.Json;

namespace ClaimTheSquareAPI.Infrastructure
{
    public class SquareRepository
    {
        const string fileName = "squares.json";

        public static List<Square> GetAll()
        {
            if (!File.Exists(fileName)) return new List<Square>();
            var json = File.ReadAllText("squares.json");
            return new List<Square>(JsonSerializer.Deserialize<Square[]>(json));
        }

        public static void AddSquare(Square square)
        {
            var squares = GetAll();
            squares.Add(square);
            WriteAllSquares(squares);
        }

        private static void WriteAllSquares(List<Square> squares)
        {
            var json2 = JsonSerializer.Serialize(squares);
            File.WriteAllText(fileName, json2);
        }
    }
}
