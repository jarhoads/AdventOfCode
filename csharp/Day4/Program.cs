using AOCLib;
using AOCLib.Models;

string textFile = @"C:\dev\AoC2023\csharp\Day4\input.txt";

//RunTest1();
//GetResult1(textFile);

//RunTest2();
GetResult2(textFile);

static void GetResult1(string textFile)
{
    var items = InputUtil.ReadTextInput(textFile);
    Console.WriteLine($"items length: {items.Count}");

    var totalPoints = new List<int>();
    for (int i = 0; i < items.Count; i++)
    {
        var row = i + 1;
        var card = Day4Lib.ConvertToCardData(items[i], row);
        var cardWinners = Day4Lib.CardWinners(card.Winners, card.Have);
        var points = Day4Lib.CardPoints(cardWinners);

        totalPoints.Add(points);
    }
    Console.WriteLine($"!!@@--> Total Points: {totalPoints.Sum()}");
}

static void RunTest1() 
{
    var data = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
    var card = Day4Lib.ConvertToCardData(data, 1);
    Console.WriteLine($"!!##--> card: {card}");

    var cardWinners = Day4Lib.CardWinners(card.Winners, card.Have);
    Console.WriteLine($"!!##--> cardWinners: {String.Join(",", cardWinners)}");

    var points = Day4Lib.CardPoints(cardWinners);
    Console.WriteLine($"!!##--> points: {String.Join(",", points)}");
}

static void RunTest2()
{
    string[] data = [
        "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
        "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
        "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
        "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
        "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
        "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
    ];

    //string[] data = [
    //    "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"
    //];

    var cards = new List<CardData>();
    for (int i=0; i<data.Length; i++)
    {
        var row = i + 1;
        var card = Day4Lib.ConvertToCardData(data[i], row);
        cards.Add(card);
    }

    var cardsWon = Day4Lib.CardsWon(cards);
    Console.WriteLine($"!!##--> cards won: {cardsWon}");

}

static void GetResult2(string textFile)
{
    var items = InputUtil.ReadTextInput(textFile);
    Console.WriteLine($"items length: {items.Count}");

    var cards = new List<CardData>();
    for (int i = 0; i < items.Count; i++)
    {
        var row = i + 1;
        var card = Day4Lib.ConvertToCardData(items[i], row);
        cards.Add(card);
    }

    var cardsWon = Day4Lib.CardsWon(cards);
    Console.WriteLine($"!!##--> cards won: {cardsWon}");
}