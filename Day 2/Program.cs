namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("./../../../input.txt");
            var total = 0;
            for (var i = 0; i < lines.Length; i += 1)
            {
                var gameID = ReadGame(lines[i]);
                if (gameID > -1)
                {
                    total += gameID;
                }
            }
            Console.WriteLine(total);
        }

        private static int ReadGame(string line)
        {
            line = line.ToLower();
            var gameContents = line.Split(":");
            var gameID = gameContents[0].Replace("game ", "");
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
                            if (number > 13)
                            {
                                return -1;
                            }
                            break;
                        case "blue":
                            if (number > 14)
                            {
                                return -1;
                            }
                            break;
                        case "red":
                            if (number > 12)
                            {
                                return -1;
                            }
                            break;
                        default:
                            throw new Exception("Unrecognised Colour" + pair[1]);
                    }
                }
            }
            return int.Parse(gameID);
        }
    }
}