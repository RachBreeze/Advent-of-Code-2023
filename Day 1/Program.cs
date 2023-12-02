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
            var firstDigit = "";
            var lastDigit = "";

            var contents = line.ToLower();

            while (!string.IsNullOrEmpty(contents))
            {
                var digit = contents.Substring(0, 1);
                if (int.TryParse(digit.ToString(), out var result))
                {
                    if (string.IsNullOrEmpty(firstDigit))
                    {
                        firstDigit = result.ToString();
                    }
                    else
                    {
                        lastDigit = result.ToString();
                    }
                    contents = contents.Substring(1);
                }
                else
                {
                    var digitData = GetDigitData(contents);
                    if (digitData != -1)
                    {
                        if (string.IsNullOrEmpty(firstDigit))
                        {
                            firstDigit = digitData.ToString();
                        }
                        else
                        {
                            lastDigit = digitData.ToString();
                        }
                        contents = contents.Substring(1);
                    }
                    else
                    {
                        contents = contents.Substring(1);
                    }
                }
            }

            if (string.IsNullOrEmpty(lastDigit))
            {
                return int.Parse(firstDigit + firstDigit);
            }
            return int.Parse(firstDigit + lastDigit);
        }

        private static int GetDigitData(string line)
        {


            if (line.StartsWith("one"))
            {
                return 1;
            }


            if (line.StartsWith("two"))
            {
                return 2;
            }


            if (line.StartsWith("three"))
            {
                return 3;
            }
            if (line.StartsWith("four"))
            {
                return 4;
            }
            if (line.StartsWith("five"))
            {
                return 5;
            }
            if (line.StartsWith("six"))
            {
                return 6;
            }
            if (line.StartsWith("seven"))
            {
                return 7;
            }
            if (line.StartsWith("eight"))
            {
                return 8;
            }
            if (line.StartsWith("nine"))
            {
                return 9;
            }
            return -1;
        }
    }
}