using AOCLib;

string textFile = @"C:\dev\AoC2023\csharp\Day3\input.txt";
//GetResult(textFile);
GetResult2(textFile);
//RunTest();
//RunTest2();

static void GetResult(string textFile)
{

    var items = InputUtil.ReadTextInput(textFile);
    Console.WriteLine($"items length: {items.Count}");

    var dataRows = new List<RowData>();
    for (int i = 0; i < items.Count; i++)
    {
        var row = Day3Lib.ConvertToRowData(items[i], i);
        dataRows.Add(row);
        System.Console.WriteLine($"!!##--> RowData: {row}");
    }

    var partNumbers = new List<int>();
    foreach (var row in dataRows)
    {
        foreach (var number in row.Numbers)
        {
            var partNumber = Day3Lib.IsPartNumber(number, dataRows, row.Id);
            System.Console.WriteLine($"!!##--> Row {row.Id} Number {number} IsPartNumber: {partNumber}");
            if (partNumber) { partNumbers.Add(number.Number); }
        }

    }

    Console.WriteLine($"Total Sum of Part Numers: {partNumbers.Sum()}");

}

static void GetResult2(string textFile)
{

    var items = InputUtil.ReadTextInput(textFile);
    Console.WriteLine($"items length: {items.Count}");

    var dataRows = new List<RowData>();
    for (int i = 0; i < items.Count; i++)
    {
        var row = Day3Lib.ConvertToRowData(items[i], i);
        dataRows.Add(row);
        System.Console.WriteLine($"!!##--> RowData: {row}");
    }

    var partNumbers = new List<int>();
    foreach (var row in dataRows)
    {
        foreach (var number in row.Numbers)
        {
            // I'm doing this to updarte the adjacents in RowSymbol
            // I know this isn't ideal or effecient but I want to move on to the next day
            var partNumber = Day3Lib.IsPartNumber(number, dataRows, row.Id, true);
            if (partNumber) { partNumbers.Add(number.Number); }
        }

    }

    var ratios = new List<int>();
    foreach (var row in dataRows)
    {

        Console.WriteLine($"!!##--> RowData: {row}");
        // get any gears with exactly 2 part numbers
        var symbols = row.Symbols ?? new List<RowSymbol>();
        foreach (var symbol in symbols)
        {

            // check for gear symbol
            if (symbol.Symbol == "*")
            {
                // check for exactly 2 part numbers
                var adjacents = symbol.Adjacents;
                if (adjacents.Count == 2)
                {
                    var ratio = adjacents[0].Number * adjacents[1].Number;
                    ratios.Add(ratio);
                }
            }
        }
    }
    Console.WriteLine($"!!##--> Ratios: {String.Join(",", ratios)}");
    Console.WriteLine($"!!##--> Sum: {ratios.Sum()}");

}

static void RunTest()
{
    var row1 = "467..114..";
    var rowData = Day3Lib.ConvertToRowData(row1, 0);

    System.Console.WriteLine($"!!##--> RowData1: {rowData}");

    var row2 = "...*......";
    var rowData2 = Day3Lib.ConvertToRowData(row2, 1);

    System.Console.WriteLine($"!!##--> RowData2: {rowData2}");

    var row3 = "..35..633.";
    var rowData3 = Day3Lib.ConvertToRowData(row3, 2);

    System.Console.WriteLine($"!!##--> RowData3: {rowData3}");

    var row4 = "......#...";
    var rowData4 = Day3Lib.ConvertToRowData(row4, 3);

    System.Console.WriteLine($"!!##--> RowData4: {rowData4}");

    var row5 = "617*......";
    var rowData5 = Day3Lib.ConvertToRowData(row5, 4);

    System.Console.WriteLine($"!!##--> RowData5: {rowData5}");

    // original
    //string[] rows = [
    //    "467..114..",
    //    "...*......",
    //    "..35..633.",
    //    "......#...",
    //    "617*......",
    //    ".....+.58.",
    //    "..592.....",
    //    "......755.",
    //    "...$.*....",
    //    ".664.598.."

    //];

    //string[] rows = [
    //    "467..114..",
    //    "...*......",
    //    "..35..633.",
    //    "......#...",
    //    "617*......",
    //    ".....+.58.",
    //    "..592.....",
    //    "......755.",
    //    "...$.*....",
    //    ".664.598..",
    //    "$345......",
    //    "..........",
    //    "#12.......",
    //    "...3.*....",
    //    "..+.4....."
    //];

    // test some edge cases
    string[] rows = [
        "12.......*..",
        "+.........34",
        ".......-12..",
        "..78........",
        "..*....60...",
        "78..........",
        ".......23...",
        "....90*12...",
        "............",
        "2.2......12.",
        ".*.........*",
        "1.1.......56"
    ];


    var dataRows = new List<RowData>();
    for (int i = 0; i < rows.Length; i++)
    {
        var row = Day3Lib.ConvertToRowData(rows[i], i);
        dataRows.Add(row);
        System.Console.WriteLine($"!!##--> RowData: {Day3Lib.ConvertToRowData(rows[i], i)}");
    }

    var partNums = new List<int>();
    foreach (var row in dataRows)
    {
        foreach (var number in row.Numbers)
        {
            var partNumber = Day3Lib.IsPartNumber(number, dataRows, row.Id);
            System.Console.WriteLine($"!!##--> Row {row.Id} Number {number} IsPartNumber: {partNumber}");
            if (partNumber) { partNums.Add(number.Number); }
        }

    }

    Console.WriteLine($"!!##--> Ttl Part Nums: {partNums.Sum()}");
}

static void RunTest2()
{
    string[] rows = [
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        "..592.....",
        "......755.",
        "...$.*....",
        ".664.598.."
    ];


    var dataRows = new List<RowData>();
    for (int i = 0; i < rows.Length; i++)
    {
        var row = Day3Lib.ConvertToRowData(rows[i], i);
        dataRows.Add(row);
        //System.Console.WriteLine($"!!##--> RowData: {Day3Lib.ConvertToRowData(rows[i], i)}");
    }

    var partNums = new List<int>();
    foreach (var row in dataRows)
    {
        foreach (var number in row.Numbers)
        {
            var partNumber = Day3Lib.IsPartNumber(number, dataRows, row.Id, true);
            //System.Console.WriteLine($"!!##--> Row {row.Id} Number {number} IsPartNumber **Gear**: {partNumber}");
            if (partNumber) { partNums.Add(number.Number); }
        }

        //Console.WriteLine($"!!##--> RowData: {row}");

    }

    var ratios = new List<int>();
    foreach (var row in dataRows)
    {

        Console.WriteLine($"!!##--> RowData: {row}");
        // get any gears with exactly 2 part numbers
        var symbols = row.Symbols ?? new List<RowSymbol>();
        foreach (var symbol in symbols)
        {
            
            // check for gear symbol
            if (symbol.Symbol == "*")
            {
                // check for exactly 2 part numbers
                var adjacents = symbol.Adjacents;
                if (adjacents.Count == 2)
                {
                    var ratio = adjacents[0].Number * adjacents[1].Number;
                    ratios.Add(ratio);
                }
            }
        }



    }
    Console.WriteLine($"!!##--> Ratios: {String.Join(",", ratios)}");
    Console.WriteLine($"!!##--> Sum: {ratios.Sum()}");

    //Console.WriteLine($"!!##--> Ttl Part Nums: {partNums.Aggregate(1, (product, num) => product * num)}");
}
