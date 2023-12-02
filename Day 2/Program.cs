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
            var green = 0;
            var red = 0;
            var blue = 0;
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
                            if (number > green)
                            {
                                green = number;
                            }
                            break;
                        case "blue":
                            if (number > blue)
                            {
                                blue = number;
                            }
                            break;
                        case "red":
                            if (number > red)
                            {
                                red = number;
                            }
                            break;
                        default:
                            throw new Exception("Unrecognised Colour" + pair[1]);
                    }
                }
            }
            var total = 0;
            if (red != 0)
            {
                total = red;
            }
            if (blue != 0)
            {
                if (total != 0)
                {
                    total = total * blue;
                }
                else
                {
                    total = blue;
                }
            }
            if (green != 0)
            {
                if (total != 0)
                {
                    total = total * green;
                }
                else
                {
                    total = green;
                }
            }
            return total;
        }
    }
}