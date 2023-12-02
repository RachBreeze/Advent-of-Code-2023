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
                var line = lines[i];
                total += GetDigit(line);
            }

            Console.WriteLine(total);
        }

        private static int GetDigit(string line)
        {
            var letters = line.ToCharArray();
            var firstDigit = "";
            var lastDigit = "";

            foreach (var letter in letters)
            {
                if (int.TryParse(letter.ToString(), out var result))
                {
                    if (string.IsNullOrEmpty(firstDigit))
                    {
                        firstDigit = result.ToString();
                    }
                    else
                    {
                        lastDigit = result.ToString();
                    }
                }
            }
            if (string.IsNullOrEmpty(lastDigit))
            {
                return int.Parse(firstDigit + firstDigit);
            }
            return int.Parse(firstDigit + lastDigit);
        }
    }
}