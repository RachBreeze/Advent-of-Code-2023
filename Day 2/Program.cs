using Day2;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var games = GetGames();
            var tooMany = games.Where(x => x.RedBalls > 12 || x.GreenBalls > 13 || x.BlueBalls > 14).Select(x => x.GameID).ToList();
            var validGames = games.Where(x => !tooMany.Contains(x.GameID));
            var total = validGames.Sum(x => x.GameID);
            Console.WriteLine(total);
        }
        static List<Game> GetGames()
        {

            var lines = File.ReadAllLines("./../../../input.txt");
            var games = new List<Game>();
            for (var i = 0; i < lines.Length; i += 1)
            {
                games.Add(ReadGame(lines[i]));
            }
            return games;
        }

        private static Game ReadGame(string line)
        {
            line = line.ToLower();
            var gameContents = line.Split(":");
            var gameID = gameContents[0].Replace("game ", "");
            var game = new Game { GameID = int.Parse(gameID) };
            var hands = gameContents[1].Split(";");
            foreach (var hand in hands)
            {
                var cubes = hand.Split(",");
                foreach (var cube in cubes)
                {
                    var pair = cube.Trim().Split(" ");
                    var number = int.Parse(pair[0]);
                    switch (pair[1])
                    {
                        case "green":
                            game.GreenBalls += number;
                            break;
                        case "blue":
                            game.BlueBalls += number;
                            break;
                        case "red":
                            game.RedBalls += number;
                            break;
                        default:
                            throw new Exception("Unrecognised Colour" + pair[1]);
                    }
                }
            }
            return game;
        }
    }
}