namespace AOCLib;
public class InputUtil
{
    public static List<string> ReadTextInput(string textFile)
    {
        if (File.Exists(textFile))
        {
            // This seems to work fine for what we are doing.
            string[] lines = File.ReadAllLines(textFile);
            return lines.Select(x => x.Trim()).ToList();
        }

        return [];
    }

    public static int ConvertToCalibration(string value)
    {
        Console.WriteLine($"value: {value}");
        value = value.Trim();
        var numbers = value.Where(c => Char.IsDigit(c));
        Console.WriteLine($"numbers - count: {numbers.Count()}");
        foreach (var item in numbers)
        {
            Console.WriteLine($"numbers - item: {item}");
        }
        
        int calibration = 0;
        var numsList = numbers.ToList();
        if (numsList.Count == 1 ) 
        {
            calibration = ToDigit($"{numsList[0]}{numsList[0]}"); 
        }
        else
        {
            
            calibration = ToDigit($"{numsList[0]}{numsList[numsList.Count - 1]}");
            Console.WriteLine($"calibration: {calibration}");
        }

        return calibration;
    }

    public static int ConvertToCalibrationWords(string value)
    {
        Console.WriteLine($"value: {value}");
        value = value.Trim();

        int num1 = 0;
        // find first digit
        var firstDigitFound = false;
        int i = 0;
        string checkString = "";
        while(!firstDigitFound && i < value.Length) 
        {
            if (Char.IsDigit(value[i])) 
            {
                firstDigitFound = true;
                num1 = ToDigit($"{value[i]}");
            }
            else
            {
                checkString += value[i];
                var checkResult = StringToDigit(checkString);
                if (checkResult != -1)
                {
                    firstDigitFound = true;
                    num1 = checkResult;
                }
            }

            i++;
        }
        
        if (firstDigitFound)
        {
            Console.WriteLine($"num1: {num1}");
        }

        int num2 = 0;
        // start at end of input and find last digit
        var secondDigitFound = false;
        int j = value.Length - 1;
        string checkString2 = "";
        while (!secondDigitFound && j >= 0)
        {
            if (Char.IsDigit(value[j]))
            {
                secondDigitFound = true;
                num2 = ToDigit($"{value[j]}");
            }
            else
            {
                checkString2 = value[j] + checkString2;
                Console.WriteLine($"checkString2: {checkString2}");

                var checkResult2 = StringToDigit(checkString2);
                if (checkResult2 != -1)
                {
                    secondDigitFound = true;
                    num2 = checkResult2;
                }
            }

            j--;
        }

        if (secondDigitFound)
        {
            Console.WriteLine($"num2: {num2}");
        }

        int calibration = ToDigit($"{num1}{num2}");
        return calibration;
    }

    public static readonly int GameRed = 0;
    public static readonly int GameGreen = 1;
    public static readonly int GameBlue = 2;

    public static List<int[]> ConvertToRGB(string game)
    {
        List<int[]> list = new List<int[]>();   
        var playedGames = game.Split(":")[1];
        Console.WriteLine($"!!##--> gameValues: {playedGames}");

        var games = playedGames.Split(";");
        foreach (var gameItems in games)
        {
            int[] rgb = [0, 0, 0];
            Console.WriteLine($"!!##--> gameItems: {gameItems}");
            var selections = gameItems.Split(',');
            foreach (var selection in selections)
            {
                Console.WriteLine($"!!##--> selection: {selection}");
                if (selection.Contains("red")) { rgb[0] = ToDigit(selection.Split(" ")[1]); }
                else if (selection.Contains("green")) { rgb[1] = ToDigit(selection.Split(" ")[1]); }
                else if (selection.Contains("blue")) { rgb[2] = ToDigit(selection.Split(" ")[1]); }
            }

            Console.WriteLine($"!!@@--> rgb: red {rgb[0]} green {rgb[1]} blue {rgb[2]}");

            list.Add(rgb);
        }
        return list;
    }

    public static bool ValidGame(string game, int red, int green, int blue) 
    {
        var gameResults = ConvertToRGB(game);
        var valids = new List<int>();
        for (int i = 0; i < gameResults.Count; i++)
        {
            if (gameResults[i][InputUtil.GameRed] > red ||
                gameResults[i][InputUtil.GameGreen] > green ||
                gameResults[i][InputUtil.GameBlue] > blue)
            {
                return false;
            }
        }

        return true;
    }

    public static int[] MaxGame(string game)
    {
        var gameResults = ConvertToRGB(game);
        int[] maxColors = [0, 0, 0];
        for (int i = 0; i < gameResults.Count; i++)
        {
            if (gameResults[i][GameRed] > maxColors[GameRed]) { maxColors[GameRed] = gameResults[i][GameRed]; }
            if (gameResults[i][GameGreen] > maxColors[GameGreen]) { maxColors[GameGreen] = gameResults[i][GameGreen]; }
            if (gameResults[i][GameBlue] > maxColors[GameBlue]) { maxColors[GameBlue] = gameResults[i][GameBlue]; }
        }

        return maxColors;
    }

    public static int GamePower(int[] game)
    {
        return game[GameRed] * game[GameGreen] * game[GameBlue];
    }

    public static int ToDigit(string value)
    {
        int digit = 0;
        int.TryParse(value, out digit);
        return digit;
    }

    public static int StringToDigit(string value)
    {
        string[] names = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        for (int i = 0; i < names.Length; i++)
        {
            var idx = value.IndexOf(names[i]);
            if (idx > -1) {
                int number = i+1;
                return  number; 
            }
        }

        return -1;
    }

    public static string DisplayList<T>(List<T> list) => String.Join(",", list);
}
