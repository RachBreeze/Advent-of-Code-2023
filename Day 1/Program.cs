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
            var contents = line.ToLower();
            var firstDigit = GetFirstDigit(contents, false);
            var lastDigit = GetLastDigit(line);
            if (string.IsNullOrEmpty(lastDigit))
            {
                return int.Parse(firstDigit + firstDigit);
            }
            return int.Parse(firstDigit + lastDigit);
        }
        private static string GetLastDigit(string contents)
        {
            char[] array = contents.ToCharArray();
            Array.Reverse(array);
            contents = new string(array);
            return GetFirstDigit(contents, true);
        }
        private static string GetFirstDigit(string contents, bool reverse)
        {
            while (!string.IsNullOrEmpty(contents))
            {
                var digit = contents.Substring(0, 1);
                if (int.TryParse(digit.ToString(), out var result))
                {
                    return result.ToString();
                }
                else
                {
                    var digitData = GetDigitData(contents, reverse);
                    if (digitData != -1)
                    {
                        return digitData.ToString();
                    }
                    contents = contents.Substring(1);
                }
            }
            return "";
        }

        private static int GetDigitData(string line, bool reverse)
        {
            if (reverse)
            {
                return GetReverseDigitData(line);
            }
            return GetStandardDigitData(line);

        }

        private static int GetReverseDigitData(string line)
        {
            if (line.StartsWith("eno"))
            {
                return 1;
            }


            if (line.StartsWith("owt"))
            {
                return 2;
            }


            if (line.StartsWith("eerht"))
            {
                return 3;
            }
            if (line.StartsWith("ruof"))
            {
                return 4;
            }
            if (line.StartsWith("evif"))
            {
                return 5;
            }
            if (line.StartsWith("xis"))
            {
                return 6;
            }
            if (line.StartsWith("neves"))
            {
                return 7;
            }
            if (line.StartsWith("thgie"))
            {
                return 8;
            }
            if (line.StartsWith("enin"))
            {
                return 9;
            }
            return -1;
        }

        private static int GetStandardDigitData(string line)
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