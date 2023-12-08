using AOCLib;

string textFile = @"C:\dev\AoC2023\csharp\Day2\input.txt";
GetResult(textFile);

static void GetResult(string textFile)
{

    var items = InputUtil.ReadTextInput(textFile);
    Console.WriteLine($"items length: {items.Count}");
    var maxGames = new List<int[]>();
    for (int i = 0; i < items.Count; i++)
    {
        var max = InputUtil.MaxGame(items[i]);
        maxGames.Add(max);
    }

    var powerSum = maxGames.Select(max => InputUtil.GamePower(max))
                           .Sum();

    Console.WriteLine("power sum of games:");
    Console.WriteLine($"sum: {powerSum}");

    //for (int i = 0; i<items.Count; i++)
    //{
    //    if (InputUtil.ValidGame(items[i], 12, 13, 14))
    //    {
    //        var valid = i + 1;
    //        valids.Add(valid);
    //    }
    //}

    //Console.WriteLine("valid games:");
    //Console.WriteLine($"{String.Join(',',valids)}");
    //Console.WriteLine($"sum: {valids.Sum()}");

    //foreach (var item in items)
    //{
    //    Console.WriteLine($"item: {item}");
    //    var gameResults = InputUtil.ConvertToRGB(item);
    //    foreach (var gameResult in gameResults)
    //    {
    //        Console.WriteLine($"!!##--> gameResult: {gameResult}");
    //        if (InputUtil.ValidGame(gameResult))
    //        {
                
    //        }
    //    }
    //}




}